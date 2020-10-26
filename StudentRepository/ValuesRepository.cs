using StudentDTO;
using StudentEntity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRepository
{

    public class ValuesRepository : IValuesRepository
        {
            private readonly IStudentEntity _entity;

            public ValuesRepository(IStudentEntity entity)
            {
                _entity = entity;
            }

            public async Task<List<Student>> GetAll()
            {
                //var usersList = await _entityUsers.GetAll();
                //return usersList;
                var studentListDTO = new List<Student>();
                var studentList = await _entity.GetAll();


            studentListDTO.AddRange(
                studentList.Select(x => new Student
                {   id=x.id,
                    name = x.name,
                    city = x.city,
                    address = x.address,
                    phone = x.phone
                    
                }).ToList());


                return studentListDTO;
            }

        //public async Task<Student> GetById(int Id)
        //{
        //    using (SqlConnection sql = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sdGetById", sql))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@id", Id));
        //            Student response = null;
        //            await sql.OpenAsync();

        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    response = MapToValue(reader);
        //                }
        //            }

        //            return response;
        //        }
        //    }
        //}

        public async Task<bool> Insert(Student insert)
        {
            var newuser = new StudentE()
            {
                name = insert.name,
                city = insert.city,
                address = insert.address,
                phone = insert.phone
            };
            var result = await _entity.Insert(newuser);
            return true;
        }

        public async Task<bool> Update(int id, Student insert)
        {
            var newuser = new StudentE()
            {
                id = insert.id,

                name = insert.name,
                city = insert.city,
                address = insert.address,
                phone = insert.phone
            };
            var result = await _entity.Update(id, newuser);
            
            return true;
        }

        public async Task<bool> DeleteById(int id)
        {
            await _entity.DeleteById(id);
            return true;
        }


    }

    }

