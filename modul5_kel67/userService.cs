using System;
using System.Collections.Generic;
using System.Text;

namespace modul5_kel67
{
    class userService
    {
        private string[,] data;
        private string email, password, roles = "";
        private string[,] histories;
        private string nama, buku1, buku2, tgl;
       

        public userService(string emails, string passwords)
        {
            email = emails;
            password = passwords;
            data = new string[2, 3] {
                {"dimaskelompok67@gmail.com", "12345", "superadmin" },
                {"davakelompok67@gmail.com", "12345", "user"  }
            };
            histories = new string[2, 4]
            {
                {"dimaskelompk67@gmail.com","Fisika Dasar","Dasar komputer dan pemrograman","25-04-2020" },
                {"davakelompk67@gmail.com","Dasar komputer dan pemrograman","Konsep jaringan Komputer","25-04-2020" },
            };
        }

        public void login()
        {
            var (status, role, buku1, buku2, tgl, nama) = CheckCredentials();
            if (status == true)
            {
                Console.WriteLine("\nWelcome " + role);
                Console.WriteLine("Logged it as user email: " + email);
                Console.WriteLine(" ");
                Console.WriteLine(nama + " Meminjam buku=");
                Console.WriteLine(buku1);
                Console.WriteLine(buku2);
                Console.WriteLine("Tanggal peminjaman="+tgl);

            }
            else
            {
                Console.WriteLine("\nInvalid Login");
            }
        }
        private (bool, string, string, string, string, string) CheckCredentials()
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] == email && data[i, 1] == password)
                {
                    roles = data[i, 2];
                    buku1 = histories[i, 1];
                    buku2 = histories[i, 2];
                    tgl = histories[i, 3];
                    nama = histories[i, 0];
                    return (true, roles, buku1, buku2, tgl, nama);

                }
            }
            return (false, roles, buku1, buku2, tgl, nama);
        }
    }
}
