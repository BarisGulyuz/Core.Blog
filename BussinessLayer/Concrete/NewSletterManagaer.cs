using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class NewSletterManagaer : INewSletterService
    {
        INewSletterDal _newSletterDal;

        public NewSletterManagaer(INewSletterDal newSletterDal)
        {
            _newSletterDal = newSletterDal;
        }

        public void AddNewSletter(NewSletter newSletter)
        {
            _newSletterDal.Insert(newSletter);
        }
    }
}
