using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vs2015.Models;

namespace vs2015.Controllers
{
    public class EventosController : Controller
    {
        private vs2015Context db = new vs2015Context();

        // GET: Eventos
        public ActionResult Index()
        {
            return View(db.Eventos.ToList());
            //return View();
        }

        public ActionResult GetEventos(string start, string end)
        {
            //ver esse filtro de data
            //var fromDate = ConvertFromUnixTimestamp(start);
            //var toDate = ConvertFromUnixTimestamp(end);

            List<Evento> eventos = db.Eventos.ToList();
            var novoeventos = from e in eventos
                              select new
                              {
                                  id = e.id,
                                  title = e.descricao,
                                  start = e.horarioInicio.ToString("yyyy-MM-ddTHH:mm:ssZ").Replace("T00:00:00Z", string.Empty),
                                  end = e.horarioFim != null ? e.horarioFim.Value.ToString("yyyy-MM-ddTHH:mm:ssZ") : string.Empty
                              };

            return Json(novoeventos.ToList(), JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public void AdicionarEvento(string title, string start)
        {
            DateTime inicio = Convert.ToDateTime(start);
            var evento = new Evento
            {
                descricao = title,
                horarioInicio = inicio,
                horarioFim = inicio.AddHours(1)
            };
            db.Eventos.Add(evento);
            db.SaveChanges();
        }

        //[HttpPost]
        public void AtualizarEvento(string id, string newEventStart, string newEventEnd, string visualizacaoAtual)
        {
            DateTime? dataFinal = null;

            //Se estiver na visualição de Mês não pode considerar o horário, somente a data pois nesta visualização o evento é 
            //tratado como evento de dia inteiro, senão fizer isto a atualização mostrará o 
            //evento como se ele tivesse no horário de 00:00 do dia
            if (visualizacaoAtual.Equals("month"))
            {
                //Se a data contém T00:00:00.000Z tem que remover antes de converter para DateTime, 
                //pois se não após converter volta um dia
                if (newEventStart.Contains("T00:00:00.000Z"))
                    newEventStart = newEventStart.Replace("T00:00:00.000Z", string.Empty);

                if (!string.IsNullOrEmpty(newEventEnd))
                {
                    if (newEventEnd.Contains("T00:00:00.000Z"))
                    {
                        newEventEnd = newEventEnd.Replace("T00:00:00.000Z", string.Empty);
                        dataFinal = Convert.ToDateTime(newEventEnd);
                    }
                }
            }

            //Tem que remover o .000Z, senão converte a hora de forma errada
            newEventStart = newEventStart.Replace(".000Z", string.Empty);
            if (!string.IsNullOrEmpty(newEventEnd))
            {
                newEventEnd = newEventEnd.Replace(".000Z", string.Empty);
                dataFinal = Convert.ToDateTime(newEventEnd);
            }

            DateTime dataInicial = Convert.ToDateTime(newEventStart);

            Evento evento = db.Eventos.Find(Convert.ToInt32(id));
            if (evento != null)
            {
                evento.horarioInicio = dataInicial;
                evento.horarioFim = dataFinal;
                db.SaveChanges();
            }
        }

        //[HttpPost]
        public ActionResult EditarEvento(string id, string titulo, string cor)
        {
            Evento evento = db.Eventos.Find(Convert.ToInt32(id));
            if (evento != null)
            {
                evento.descricao = titulo;
                db.SaveChanges();
                return Json(new { Sucesso = true }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { Sucesso = false }, JsonRequestBehavior.AllowGet);
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,horarioInicio,horarioFim,descricao")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evento);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,horarioInicio,horarioFim,descricao")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult Backend()
        //{
        //    return new Dpc().CallBack(this);
        //}

        //class Dpc : DayPilotCalendar
        //{
        //    vs2015Context db = new vs2015Context();

        //    protected override void OnInit(InitArgs e)
        //    {
        //        Update(CallBackUpdateType.Full);
        //    }

        //    protected override void OnEventResize(EventResizeArgs e)
        //    {
        //        var toBeResized = (from ev in db.Eventos where ev.id == Convert.ToInt32(e.Id) select ev).First();
        //        toBeResized.horarioInicio = e.NewStart;
        //        toBeResized.horarioFim = e.NewEnd;
        //        db.SaveChanges();
        //        Update();
        //    }

        //    protected override void OnEventMove(EventMoveArgs e)
        //    {
        //        var toBeResized = (from ev in db.Eventos where ev.id == Convert.ToInt32(e.Id) select ev).First();
        //        toBeResized.horarioInicio = e.NewStart;
        //        toBeResized.horarioFim = e.NewEnd;
        //        db.SaveChanges();
        //        Update();
        //    }

        //    protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
        //    {
        //        var toBeCreated = new Evento { horarioInicio = e.Start, horarioFim = e.End, descricao = (string)e.Data["name"] };
        //        db.Eventos.Add(toBeCreated);
        //        db.SaveChanges();
        //        Update();
        //    }

        //    protected override void OnFinish()
        //    {
        //        if (UpdateType == CallBackUpdateType.None)
        //        {
        //            return;
        //        }

        //        Events = from ev in db.Eventos select ev;

        //        DataIdField = "id";
        //        DataTextField = "descricao";
        //        DataStartField = "horarioInicio";
        //        DataEndField = "horarioFim";
        //    }

        //}
    }
}
