using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_CR
{
    public class human
    {
        public int id { get; set; }

        public string name { get; set; }

        public string family { get; set; }

        public byte age { get; set; } 

         db db1 = new db();


        public bool register (human h)
        {
            if (!exist(h))
            {
                db1.Humans.Add(h);
                db1.SaveChanges();
                return true;
            }
            else
            { 
                return false;
            }
            


        }

        public bool exist (human h)
        {

            var a = db1.Humans.Where(i=>i.name== h.name && i.family == h.family && i.age == h.age).ToList();
            if (a.Count==1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public human readbyid  ( int id )
        {
            return db1.Humans.Where(i => i.id == id).FirstOrDefault();
        }
        public List<human> readall ()
        {
            return db1.Humans.ToList();
        }
        public List<human> readbyname(string s)
        {
            return db1.Humans.Where(i => i.name.Contains(s) || i.family.Contains(s) || (i.age).ToString() == s).ToList();
        }

        public void delete (int id)
        {
          human h =  db1.Humans.Where(i => i.id == id).FirstOrDefault();
            db1.Humans.Remove(h);
            db1.SaveChanges();
        }

        public void update (human h , int id )
        {
           var a = db1.Humans.Where(i => i.id == id ).FirstOrDefault(); 
            a.name = h.name;
            a.family = h.family;
            a.age = h.age;
            db1.SaveChanges();
        }
    }
}
