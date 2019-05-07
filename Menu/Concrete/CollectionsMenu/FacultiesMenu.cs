using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu.Abstract;
using Models.Entities.Abstract;
using Repository.Abstract;
using Models.Collections.Concrete;
using Menu.Concrete.MainMenu;
using Repository.Concrete.Database.Repositories;
using Models.Entities.Concrete;

namespace Menu.Concrete.CollectionsMenu
{
    public class FacultiesMenu : ICollectionMenu
    {
        public bool Add(IRepository facultiesRepo, object facultiesCollection)
        {
            Faculty faculty = new Faculty();
            try
            {
                Console.Write("Input Name: ");
                faculty.Name = Convert.ToString(Console.ReadLine());
                Console.Write("Input Description: ");
                faculty.Description = Convert.ToString(Console.ReadLine());
                ((FacultiesRepository)facultiesRepo).Insert(faculty);
                ((FacultiesCollection)facultiesCollection).Add(faculty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return true;
        }
        public bool Update(IRepository facultiesRepo, object facultiesCollection, long id)
        {
            int index = (int)((Faculty)(((FacultiesCollection)facultiesCollection).GetAll()[(int)id])).Id;
            Faculty oldFaculty = (Faculty)((FacultiesRepository)facultiesRepo).GetByID(index);
            Faculty faculty = new Faculty();

            try
            {
                faculty.Id = oldFaculty.Id;
                Console.Write("Input Name (" + oldFaculty.Name + "): ");
                faculty.Name = Convert.ToString(MenuHelper.InputString(Convert.ToString(oldFaculty.Name)));
                Console.Write("Input Description (" + oldFaculty.Description + "): ");
                faculty.Description = Convert.ToString(MenuHelper.InputString(Convert.ToString(oldFaculty.Description)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            ((FacultiesRepository)facultiesRepo).Update(faculty);
            ((FacultiesCollection)facultiesCollection).Update(faculty);
            return true;
        }
        public bool Delete(IRepository facultiesRepo, object facultiesCollection, long id)
        {
            int index = (int)((Faculty)(((FacultiesCollection)facultiesCollection).GetAll()[(int)id])).Id;
            ((FacultiesRepository)facultiesRepo).Delete(index);
            ((FacultiesCollection)facultiesCollection).Delete(index);

            return true;
        }
        public void Print(object facultiesCollection, long id)
        {
            FacultiesCollection faculties = ((FacultiesCollection)facultiesCollection);
            for (int i = 0; i < faculties.Length(); i++)
            {
                MenuHelper.PrintArrow((int)id, i);
                Console.WriteLine(faculties.GetAll()[i]);
            }
        }
        public int Length(object facultiesCollection)
        {
            return ((FacultiesCollection)facultiesCollection).Length();
        }
    }
}
