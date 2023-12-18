using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManageStaffDBApp.Model.Data;

namespace ManageStaffDBApp.Model
{
    internal static class DataWorker
    {
        /*// НУЖНО СДЕЛАТЬ ЧЕРЕЗ КОНСТРУКТОР, и дальше отрефакторить
        //private readonly ApplicationContext _db;
        //public DataWorker(ApplicationContext db)
        //{
        //    _db = db;
        //}*/

        #region GET ALL ...

        //получить все отделы
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Departments.ToList();
                return result;
            }
        }

        //получить все позиции
        public static List<Position> GetAllPositions()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Positions.ToList();
            }
        }

        //получить все сотрудников
        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.ToList();
            }
        }

        #endregion


        #region ADD
        // ADD
        //создать отдел
        public static string CreateDepartment(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Departments.Any(dep => dep.Name == name))
                {
                    Department newDepartment = new Department()
                    {
                        Name = name
                    };

                    db.Departments.Add(newDepartment);
                    db.SaveChanges();
                    return "Отдел создан.";
                }
            }

            return "Уже существует";

            /*//string result = "Уже существует";
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    //проверяем существует ли отдел
            //    bool checkIsExist = db.Departaments.Any(dep => dep.Name == name);
            //    if (!checkIsExist)
            //    {
            //        Departament newDepartament = new Departament 
            //        { 
            //            Name = name 
            //        };
            //        db.Departaments.Add(newDepartament);
            //        db.SaveChanges();
            //        result = "Сделано";
            //    }
            //}
            //return result;*/
        }

        //создать позицию
        public static string CreatePosition(string name, decimal salary, int maxNumber, Department department)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Positions.Any(pos => pos.Name == name && pos.Salary == salary))
                {
                    Position newPosition = new Position()
                    {
                        Name = name,
                        Salary = salary,
                        MaxNumber = maxNumber,
                        DepartmentId = department.Id
                    };

                    db.Positions.Add(newPosition);
                    db.SaveChanges();
                    return "Позиция создана.";
                }
            }

            return "Уже существует";

            /*string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем существует ли позиция 
                bool checkIsExist = db.Positions.Any(pos => pos.Name == name && pos.Salary == salary);
                if (!checkIsExist)
                {
                    Position newPosition = new Position 
                    { 
                        Name = name,
                        Salary = salary,
                        MaxNumber = maxNumber,
                        DepartamentId = departament.Id
                    };
                    db.Positions.Add(newPosition);
                    db.SaveChanges();
                    result = "Сделано";
                }
            }
            return result;*/
        }

        //создать сотрудника
        public static string CreateUser(string name, string surname, string phone, Position position)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Users.Any(u => u.Name == name && u.Surname == surname && u.Position == position))
                {
                    User newUser = new User()
                    {
                        Name = name,
                        Surname = surname,
                        Phone = phone,
                        PositionId = position.Id
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return "Пользователь создан.";
                }
            }

            return "Уже существует";

            /*string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверяем существует ли позиция 
                bool checkIsExist = db.Users.Any(u => u.Name == name && u.Surname == surname && u.Position == position);
                if (!checkIsExist)
                {
                    User newUser = new User
                    {
                        Name = name,
                        Surname = surname,
                        Phone = phone,
                        PositionId = position.Id
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Сделано";
                }
            }
            return result;*/
        }

        #endregion


        #region DELETE

        //удаление отдел
        public static string DeleteDepartment(Department departament)
        {
            /*//string result = "Отдела не существует";
            //using(ApplicationContext db = new ApplicationContext())
            //{
            //    db.Departaments.Remove(departament);
            //    db.SaveChanges();
            //    result = $"Сделано! Отдел {departament.Name} удален";
            //}
            //return result;*/

            using (ApplicationContext db = new ApplicationContext())
            {
                var existingDepartment = db.Departments.Find(departament.Id);
                if (existingDepartment == null)
                {
                    return "Отдела не существует.";
                }

                db.Departments.Remove(existingDepartment);
                db.SaveChanges();
                return $"Сделано! Отдел {existingDepartment.Name} удален.";
            }
        }

        //удаление позицию
        public static string DeletePosition(Position position)
        {
            /*//string result = "Позиции не существует";
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    db.Positions.Remove(position);
            //    db.SaveChanges();
            //    result = $"Сделано! Позиция {position.Name} удалена";
            //}
            //return result;*/

            using (ApplicationContext db = new ApplicationContext())
            {
                var existingPosition = db.Positions.Find(position.Id);
                if (existingPosition == null)
                {
                    return "Позиции не существует.";
                }

                db.Positions.Remove(existingPosition);
                db.SaveChanges();
                return $"Сделано! Позиция {existingPosition.Name} удалена.";
            }
        }

        //удаление сотрудника
        public static string DeleteUser(User user)
        {
            /*//string result = "Сотрудника не существует";
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    db.Users.Remove(user);
            //    db.SaveChanges();
            //    result = $"Сделано! Сотрудник {user.Name} удален";
            //}
            //return result;*/

            using (ApplicationContext db = new ApplicationContext())
            {
                var existingUser = db.Users.Find(user.Id);
                if (existingUser == null)
                {
                    return "Сотрудника не существует.";
                }

                db.Users.Remove(existingUser);
                db.SaveChanges();
                return $"Сделано! Сотрудник {existingUser.Name} удален.";
            }
        }

        #endregion


        #region EDIT

        //редактир отдел
        public static string EditDepartment(Department oldDepartment, string newName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                if (department == null)
                {
                    return "Позиции не существует.";
                }

                department.Name = newName;
                db.SaveChanges();
                return $"Сделано! Отдел {department.Name} изменен."; //изменить предложение. Тк выкидывает нов.имя
            }
        }

        //редактир позицию
        public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSalary, Department newDepartment)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Position position = db.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);
                if (position == null)
                {
                    return "Позиции не существует.";
                }

                position.Name = newName;
                position.Salary = newSalary;
                position.MaxNumber = newMaxNumber;
                position.DepartmentId = newDepartment.Id;

                db.SaveChanges();
                return $"Сделано! Позиция {position.Name} изменена."; //изменить предложение. Тк выкидывает нов.имя
            }
        }

        //редактир сотрудника
        public static string EditUser(User oldUser, string newName, string newSurname, string newPhone, Position newPosition)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == oldUser.Id);
                if (user == null)
                {
                    return "Позиции не существует.";
                }

                user.Name = newName;
                user.Surname = newSurname;
                user.Phone = newPhone;
                user.PositionId = newPosition.Id;

                db.SaveChanges();
                return $"Сделано! Сотрудник {user.Name} изменен."; //изменить предложение. Тк выкидывает нов.имя
            }
        }

        #endregion

        /// !!!! Можно собрать в один метод по идее. (Через дженерик?)

        //получение позиции по id позиции
        public static Position GetPositionById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Position pos = db.Positions.FirstOrDefault(a => a.Id == id);
                return pos;
            }
        }

        //получение отдела по id отдела
        public static Department GetDepartmentById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department dep = db.Departments.FirstOrDefault(a => a.Id == id);
                return dep;
            }
        }


        //получение всех пользователей по id позиции
        public static List<User> GetAllUsersByPositionId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //List<User> users = (from user in GetAllUsers()
                //                   where user.PositionId == id
                //                   select user).ToList();

                List<User> users = GetAllUsers().Where(u => u.PositionId == id).ToList();
                return users;
            }
        }

        //получение всех позиций по id отдела
        public static List<Position> GetAllPositionsByDepartmentId(int id)
        {
            List<Position> positions = GetAllPositions().Where(w => w.DepartmentId == id).ToList();
            return positions;
        }
    }
}
