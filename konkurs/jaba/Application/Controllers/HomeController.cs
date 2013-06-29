using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowGame()
        {
            FieldModel model = new FieldModel();
            if (model.EnemyFrog == null)
            {
                model.Init();
            }
            return View(model);
        }

        public ActionResult ShowGameMove(FieldModel model)
        {
            ModelState.Clear();
            model.Radius--;
            if (model.Bullets == null)
            {
                model.Bullets = new List<Bullet>();
            }
            int oldBullets = model.BulletsCount;
            model.CalculateMyFrogMove();
            model.CalculateEnemyFrogMove();
            model.ShootMyFrog();
            model.ShootEnemyFrog();
            model.PlayMyMove();
            model.PlayEnemyMove();
            model.MoveAllBullets(oldBullets);
            model.CollisionDetector();
            if (model.EnemyFrog.IsAlive == false || model.EnemyFrog.IsAlive == false)
            {
                return View("Final", model);
            }
            return View("ShowGame",model);
        }

        public ActionResult Final(FieldModel model)
        {
            return View(model);
        }
    }
}
