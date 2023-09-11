using System.ComponentModel;

namespace QLSach_8_đ
{
    internal class Program
    {

       
        static void Main()
        {
            bool exit = false;
            Library library = new Library();
            while (!exit)
            {
                Console.WriteLine(" == CHUONG TRINH MENU QUAN LY SACH ==");
                Console.WriteLine("1.   THEM SACH !");
                Console.WriteLine("2.   XOA MOT CUON SACH !");
                Console.WriteLine("3    THAY DOI THONG TIN MOT CUON SACH !");
                Console.WriteLine("4.   XUAT THONG TIN TAT CA CUON SACH  !");
                Console.WriteLine("5.   TIM KIEM SACH CO TEN CHUA TU  'LAP TRINH' !");
                Console.WriteLine("6.   NHAP SO K VA  GIA TIEN P, TRA VE TOI DA K CUON SACH CO GIA TIEN <= P ");
                Console.WriteLine("7.   NHAP DS TAC GIA TU BAN PPHIM ");
                Console.WriteLine("0.   THOAT CHUONG TRINH !");

                Console.WriteLine(" CHON CAC TUY CHON !");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1"://nhap mot cuon sach//
                        {
                            Console.WriteLine(" nhap ten sach ");
                            string tensach = Console.ReadLine();
                            Console.WriteLine(" nhap ma sach");
                            int masach = int.Parse(Console.ReadLine());
                            Console.WriteLine("  nhap tac gia ");
                            string tacgia = Console.ReadLine();
                            Console.WriteLine(" nhap don gia sach");
                            double dongia = double.Parse(Console.ReadLine());

                            Sach newsach = new Sach
                            {
                                tenSach = tensach,
                                maSach = masach,
                                tacGia = tacgia,
                                donGia = dongia,
                            };
                            library.AddSach(newsach);
                            Console.WriteLine("Thêm sách thành công!");
                            break;
                        }
                    case "2":// xoa mot cuon sach 

                        {
                            Console.WriteLine(" Nhap ma sach hoac ten sach de xoa ");
                            string input   = Console.ReadLine();
                            if (int.TryParse(Console.ReadLine(), out int maSach))
                            {
                                bool xoatheoma = library.xoasach(maSach);
                                if(xoatheoma)
                                {
                                    Console.WriteLine("Xoa sach thanh cong theo ma sach !!");

                                }
                                else
                                {
                                    Console.WriteLine(" khong tim thay sach voi ma vua nhap !!");
                                }
                            }
                            else
                            {
                                bool xoatheotensach = library.xoasach(input);
                                if(xoatheotensach)
                                {
                                    Console.WriteLine("Xoa sach thanh cong theo ten sach");
                                }
                                else
                                {
                                    Console.WriteLine("Khong tim thay sach voi ten vua nhap");
                                }
                            }
                            break;
                        }
                    case "3"://thay doi thong tin mot cuon sach
                        Console.WriteLine(" nhap ma sach de cap nhat ");
                        if(int.TryParse(Console.ReadLine(), out int  updatasach_masach))
                        {
                            Sach existingsach = library.GetSachList().FirstOrDefault(Sach  => Sach.maSach == updatasach_masach);
                            if(existingsach!= null)
                            {
                                Console.WriteLine("nhap ten sach moi : ");
                                string newTensach = Console.ReadLine();
                                Console.WriteLine("nhap tac gia moi: ");
                                string newTacgia = Console.ReadLine();
                                Console.WriteLine(" nhap don  gia moi:");
                                //double newDongia
                                if (int.TryParse(Console.ReadLine(), out int newDongia))
                                {
                                    bool updataed = library.capnhatsach(updatasach_masach, newTensach, newTacgia, newDongia);
                                    if(updataed)
                                    {
                                        Console.WriteLine("cap nhat thong tin sach thanh cong ! ");
                                    }
                                    else
                                    {
                                        Console.WriteLine(" khong the cap nhat sach! k tim thay sach voi id da nhap");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("don gia k hop le ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("khong tim thay sach voi ma vua nhap");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" ma sach k hop le !");
                        }

                        break;
                        
                    case "4":// xuat danh sach Sach
                        {
                            List<Sach> allSach = library.GetSachList();
                            Console.WriteLine("== Danh sach SACH ==");
                            foreach ( var sach in allSach)
                            {
                                // Console.WriteLine("ma sach      || Ten sach     || Tac gia      || Don gia"
                                // , maSach, tenSach);
                                {
                                    Console.WriteLine($"Ma sach: {sach.maSach}, Ten sach: {sach.tenSach}, Tac gia: {sach.tacGia}, Don gia: {sach.donGia}");
                                }
                            }
                            break;
                        }
                    case "5":// tim sach
                        Console.WriteLine("nhap tu khoa can tim kiem");
                        String keyword = Console.ReadLine();
                        List<Sach> foundsach = library.timSach(keyword);
                        Console.WriteLine("ket qua tim kiem  ");
                        foreach (var sach in foundsach)
                        {
                            Console.WriteLine($"Ten sach :{sach.tenSach}, MA SACH :{sach.maSach}");
                        }

                        break;
                    case "6":// cai nay kho qua :< cac ban tu lam nha 

                        break;
                    case "7"://nhap danh sach tac gia tu ban phim 
                        Console.WriteLine("Nhap danh sach tac gia(nhap end de ket thuc nhap):");
                        List<string> Tacgias = new List<string>();
                        while(true)
                        {
                            Console.WriteLine("Nhap ten tac gia: ");
                            string tacgia = Console. ReadLine();
                            if(string.Equals(tacgia,"end",StringComparison.OrdinalIgnoreCase))
                            {
                                break;
                            }
                            Tacgias.Add(tacgia);    

                        }
                        Console.WriteLine(" /n== DANH SACH TAC GIA ==");
                        foreach (var tacgia in Tacgias)
                        {
                            Console.WriteLine(" Tac gia {0}", tacgia);
                            List<Sach> sachoftacgia = library.Getsachtacgia(tacgia);
                            foreach (var sach in sachoftacgia)
                            {
                                Console.WriteLine(sach);
                            }
                        }

                        break; 
                    case "0":
                        { 
                            exit = true;
                            Console.WriteLine("ket thuc chuong trinh.!!");
                        break;
                              
                        }
                    default:
                        Console.WriteLine(" tuy chon k hop le. chon lai ");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}