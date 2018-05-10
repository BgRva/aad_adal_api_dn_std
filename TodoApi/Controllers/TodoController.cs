using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AADx.Common.Models;
using AADx.TodoApi.DAL;

namespace AADx.TodoApi.Controllers
{
    [Authorize]
    public class TodoController : ApiController
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private TodoContext db = new TodoContext();

        // GET: api/Todo
        [Authorize(Roles = "ToDoObserver,ToDoWriter,ToDoApprover,ToDoAdmin,GlobalAdmin")]
        public IQueryable<TodoItem> GetTodoItems()
        {
            logger.Debug("returning all ...");
            return db.TodoItems;
        }

        // GET: api/Todo/5
        [Authorize(Roles = "ToDoObserver,ToDoWriter,ToDoApprover,ToDoAdmin,GlobalAdmin")]
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult GetTodoItem(long id)
        {
            logger.DebugFormat("Getting todo {0}", id);
            TodoItem todoItem = db.TodoItems.Find(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // PUT: api/Todo/5
        [Authorize(Roles = "ToDoApprover,ToDoAdmin,GlobalAdmin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodoItem(long id, TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            logger.Debug(string.Format("Updating item with id {0}", item.Id));
            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(item);
        }

        // POST: api/Todo
        [Authorize(Roles = "ToDoWriter,ToDoAdmin,GlobalAdmin")]
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult PostTodoItem(TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                logger.Debug("Item is not valid");
                return BadRequest(ModelState);
            }

            db.TodoItems.Add(item);
            db.SaveChanges();
            logger.Debug(string.Format("Created item with id {0}", item.Id));

            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        // DELETE: api/Todo/5
        [Authorize(Roles = "ToDoAdmin,GlobalAdmin")]
        [ResponseType(typeof(TodoItem))]
        public IHttpActionResult DeleteTodoItem(long id)
        {
            TodoItem todo = db.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            logger.Debug(string.Format("Deleting item with id {0}", todo.Id));
            db.TodoItems.Remove(todo);
            db.SaveChanges();

            return Ok(todo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoItemExists(long id)
        {
            return db.TodoItems.Count(e => e.Id == id) > 0;
        }
    }
}