using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practica2.Repository;
using System.Web.Mvc;

namespace Practica2.Areas.ChinokBase.Controllers
{

    [Authorize]
   // [ExceptionControl]
    public class ChinokBaseController<T> : System.Web.Mvc.Controller
       where T : class
    {   //creamos un controlado base , 
        //definimos un Ireposit, para utilizar las implementaciones de esa interface
        //tener un nombre de variable
        protected IRepository<T> _repository;

        public ChinokBaseController()
        {
            _repository = new BaseRepository<T>();
        }

    }
}