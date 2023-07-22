using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CutwrightsCRUD.Interface;
using CutwrightsCRUD.Models;
using PagedList;

namespace CutwrightsCRUD.Controllers
{
    public class BoardsController : Controller
    {
        private readonly IBoardsStore _context;

        public BoardsController(IBoardsStore context)
        {
            _context = context;
        }
        public IActionResult Index(int? pageNumber)
        {
            int pageSize = 10;  //FIX IT VV  - Add the configure 
            return View(PaginatedList<BoardsEntity>.Create(_context.GetAllBoards(), pageNumber ?? 1, pageSize));
             return View(_context.GetAllBoards());
          
            //int pageNumber2 = (pageNumber ?? 1);
            //return View(_context.GetAllBoards().ToList().ToPagedList(pageNumber2, pageSize));

            
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(BoardsEntity boardsdata)
        {
            _context.Create(boardsdata);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string _id)
        {
            var board = _context.GetBoardsDetails(_id);
            return View(board);
        }

        [HttpPost]
        public IActionResult EditPost(string _id,BoardsEntity boardsdata)
        {
            _context.Update(_id,boardsdata);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string _id)
        {
            var board = _context.GetBoardsDetails(_id);
            return View(board);
        }

        [HttpGet]
        public IActionResult Delete(string _id)
        {
            var board = _context.GetBoardsDetails(_id);
            return View(board);
        }


        [HttpPost]
        public IActionResult DeletePost(string _id)
        {
            _context.Delete(_id);
            return RedirectToAction("Index");
        }
    }
}
