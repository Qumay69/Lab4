using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class Note<T> : ICloneable, IComparable<Note<T>>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public T PhoneNumber { get; set; }
        public int[] BirthDate { get; set; }

        public Note(string lastName, string firstName, T phoneNumber, int[] birthDate)
        {
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
        }

        public object Clone()
        {
            return new Note<T>(LastName, FirstName, PhoneNumber, (int[])BirthDate.Clone());
        }

        public int CompareTo(Note<T> other)
        {
            string thisPhoneStr = PhoneNumber.ToString().Substring(0, 3);
            string otherPhoneStr = other.PhoneNumber.ToString().Substring(0, 3);
            return thisPhoneStr.CompareTo(otherPhoneStr);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}, Телефон: {PhoneNumber}, Дата рождения: {BirthDate[0]}/{BirthDate[1]}/{BirthDate[2]}";
        }


        public class NoteComparer : IComparer<Note<T>>
        {
            public int Compare(Note<T> x, Note<T> y)
            {
                int lastNameComparison = string.Compare(x.LastName, y.LastName, StringComparison.Ordinal);
                if (lastNameComparison != 0)
                    return lastNameComparison;

                return string.Compare(x.FirstName, y.FirstName, StringComparison.Ordinal);
            }
        }
    }
}
