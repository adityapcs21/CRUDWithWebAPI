using StudentDTO;
using StudentEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public interface IValuesRepository
    {
        
            Task<List<Student>> GetAll();

            Task<bool> Insert(Student user);
        Task<bool> Update(int Id, Student insert);
        Task<bool> DeleteById(int Id);
        //Task GetById(int id);


    }
    }


