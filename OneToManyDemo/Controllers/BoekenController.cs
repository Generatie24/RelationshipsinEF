using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using OneToManyDemo.Data;
using OneToManyDemo.Models;
using OneToManyDemo.Models.ViewModels;
using System.Runtime.InteropServices;

namespace OneToManyDemo.Controllers
{
    public class BoekenController : Controller
    {
        readonly BoekenDbContext _context;
        public BoekenController(BoekenDbContext dbContext)
        {
                _context = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var boekAuteurViewModel = _context.Boeks
                .Include(b => b.Auteur)
                .Select(b => new BoekAuteurViewModel
                {
                    BoekId = b.BoekId,
                    Titel = b.Titel,
                    AuteurNaam = b.Auteur.Naam
                });

            return View(boekAuteurViewModel);
        }
        public async Task<IActionResult> Filters(int? GeselecteerdeAuteurId)
        {
            var auteurs = await _context.Auteurs.ToListAsync();

            IQueryable<Boek> boekenQuery = _context.Boeks.Include(b => b.Auteur);

            if (GeselecteerdeAuteurId.HasValue)
            {
                boekenQuery = boekenQuery.Where(b => b.AuteurId == GeselecteerdeAuteurId);
            }

            var boeken = await boekenQuery.ToListAsync();

            var boekenViewModel = boeken.Select(b => new BoekAuteurViewModel
            {
                BoekId = b.BoekId,
                Titel = b.Titel,
                AuteurNaam = b.Auteur.Naam
            }).ToList();

            var filtersViewModel = new BoekenViewModel
            {
                Auteurs = auteurs,
                Boeken = boekenViewModel,
                GeselecteerdeAuteurId = GeselecteerdeAuteurId ?? 0
            };



            return View(filtersViewModel);
        }
        public async Task<IActionResult> Create()
        {
            var auteurs = await _context.Auteurs.ToListAsync();
            var viewModel = new CreateBoekViewModel
            {
               
                Auteurs = auteurs
            };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBoekViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Auteurs = await _context.Auteurs.ToListAsync();
                return View(viewModel);
            }
            var newBoek = new Boek
            {
                Titel = viewModel.Titel,
                AuteurId = viewModel.AuteurId,
                IsAvailable = viewModel.IsAvailable,
                IsNewRelease = viewModel.IsNewRelease,
                IsBestSeller = viewModel.IsBestSeller,
                BindingType = viewModel.BindingType

            };
            _context.Boeks.Add(newBoek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Filters));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var boek = await _context.Boeks
                .Include(b => b.Auteur)
                .FirstOrDefaultAsync(b => b.BoekId == id);

            if (boek == null)
            {
                return NotFound();
            }

            return View(boek);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var boek = await _context.Boeks
               .Include(b => b.Auteur)
               .FirstOrDefaultAsync(b => b.BoekId == id);

            if (boek == null)
            {
                return NotFound();
            }

            var auteurs = await _context.Auteurs.ToListAsync();

            var viewModel = new EditBoekViewModel
            {
                BoekId = boek.BoekId,
                Titel = boek.Titel,
                AuteurId = boek.AuteurId,
                Auteurs = auteurs,
                IsAvailable = boek.IsAvailable.GetValueOrDefault(),
                IsNewRelease = boek.IsNewRelease.GetValueOrDefault(),
                IsBestSeller = boek.IsBestSeller.GetValueOrDefault(),
                BindingType = boek.BindingType
            };

            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBoekViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Auteurs = await _context.Auteurs.ToListAsync();

                return View(viewModel);
            }
            var boek = await _context.Boeks.FindAsync(viewModel.BoekId);
            if (boek == null)
            {
                return NotFound();
            }

            var auteurs = await _context.Auteurs.ToListAsync();

            boek.Titel = viewModel.Titel;
            boek.AuteurId = viewModel.AuteurId;
            boek.IsAvailable = viewModel.IsAvailable;
            boek.IsNewRelease = viewModel.IsNewRelease;
            boek.IsBestSeller = viewModel.IsBestSeller;
            boek.BindingType = viewModel.BindingType;

            _context.Update(boek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Filters));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeks
                .Include(b => b.Auteur)
                .FirstOrDefaultAsync(b => b.BoekId == id);
            if (boek == null)
            {
                return NotFound();
            }

            return View(boek);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boek = await _context.Boeks.FindAsync(id);
            if (boek == null)
            {
                return NotFound();
            }

           
            _context.Boeks.Remove(boek);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Filters));
        }
    }
}
