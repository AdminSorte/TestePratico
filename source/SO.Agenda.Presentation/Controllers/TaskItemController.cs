using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SO.Agenda.Application.AppServices.Interfaces;
using SO.Agenda.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SO.Agenda.Presentation.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ITaskItemAppService _taskItemAppService;
        public TaskItemController(ITaskItemAppService taskItemAppService)
        {
            _taskItemAppService = taskItemAppService;
        }
        // GET: TaskItemController
        public async Task<ActionResult> Index()
        {
            try
            {
                var taskItem = new TaskItemFiltro();
                taskItem.TaskItens = await _taskItemAppService.GetAllAsNoTrackingAsync();
                return View(taskItem);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(TaskItemFiltro taskItem)
        {
            try
            {
                if (!string.IsNullOrEmpty(taskItem.Title))
                {
                    var title = taskItem.Title;
                    taskItem.TaskItens = await _taskItemAppService.Get(x => x.Title.Contains(title));
                }
                else
                {
                    taskItem.TaskItens = await _taskItemAppService.GetAllAsNoTrackingAsync();
                }
                return View(taskItem);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }
           
          
            return View(taskItem);
        }
        // GET: TaskItemController/Details/5
        public async Task<ActionResult> Details(Int32 id)
        {
            try
            {
                var taskItem = await _taskItemAppService.FindAsync(id);
                return View(taskItem);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }          
            return View();
        }

        // GET: TaskItemController/FormTask/1
        [HttpGet]
        public async Task<ActionResult> FormTask(Int32? id)
        {
            try
            {
                var taskItem = new TaskItemViewModel();
                if (id != null)
                {
                    taskItem = await _taskItemAppService.FindAsync(id.Value);
                    return View(taskItem);
                }
            }
            catch(Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }
           
            return View();
        }

        // POST: TaskItemController/FormTask
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FormTask(TaskItemViewModel taskItem)
        {
            try
            {
                if (taskItem.Id != 0)
                {
                    _taskItemAppService.Update(taskItem);
                }
                else
                {
                    await _taskItemAppService.AddAsync(taskItem);
                }
                TempData["Ok"] = "Operation performed successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }             
            
            return View();

        }

        // POST: TaskItemController/Delete/5
        public async Task<ActionResult> Delete(Int32 id)
        {
            try
            {
                await _taskItemAppService.RemoveAsync(id);
                TempData["Ok"] = "Task item successfully deleted";
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
