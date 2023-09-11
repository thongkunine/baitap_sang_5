using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace QLSach_8_đ
{   
    internal class Sach
    {
      

        public int maSach { get; set; }
        public string tenSach { get; set; }
        public string tacGia { get; set; }
        public double donGia { get; set; }



    }
    internal class Library
    { 
        private List<Sach> sachList;
        public Library()
        {
            sachList = new List<Sach>();    
        }
        public void AddSach(Sach sach)
        {
            sach.maSach = sachList.Count+1;
            sachList.Add(sach);
        }
        public List<Sach> GetSachList() 
        {   
            return sachList;
        }
        public List<Sach> timSach(string keyword)
        {
            return sachList.FindAll(Sach =>
           Sach.tenSach.Contains(keyword, StringComparison.OrdinalIgnoreCase));
           
        }
        public  bool  xoasach (int xoasach_theoma)
        {
            Sach sachToRemove = sachList.FirstOrDefault(Sach =>
            Sach.maSach == xoasach_theoma);
            {
                if (sachToRemove != null)
                {
                    sachList.Remove(sachToRemove);
                    
                    return true;
                }
                return false;

            }
        }
        public bool  xoasach  ( string xoasach_theoten)
        {
            Sach sachToRemove = sachList.FirstOrDefault(Sach =>
            string.Equals(Sach.tenSach, xoasach_theoten, StringComparison.OrdinalIgnoreCase));
            if (sachToRemove != null)
            {
                sachList.Remove(sachToRemove);
                return true;
            }
            return  false;
        }
        public bool capnhatsach ( int newmasach, string newtensach, string newtacgia, double newdongia)
        {
            Sach sachToupdata = sachList.FirstOrDefault(Sach =>
            Sach.maSach == newmasach);
            if (sachToupdata != null)
            {
                sachToupdata.maSach = newmasach;
                sachToupdata.tenSach = newtensach;
                sachToupdata.tacGia = newtacgia;
                sachToupdata.donGia = newdongia;
                return true;
            }
            return false;
        } 
        public List<Sach> Getsachtacgia(string tacgia)
        {
            return sachList.Where(Sach=>
            Sach.tacGia.Equals(tacgia, StringComparison.OrdinalIgnoreCase)).ToList();

        }

    }
    
}
