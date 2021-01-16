using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.Function
{
    public static class TrangThai
    {
        public static string TaoPhieu = "Đang giao dịch";
        public static string ChoDuyet = "Chờ duyệt";
        public static string DaDuyet = "Đã duyệt";
        public static string HoanThanh = "Hoàn thành";
        public static string DaHuy = "Hủy";
    }

    public static class LoaiPhieu
    {
        public static string NhapKho = "Nhập kho";
        public static string XuatKho = "Xuất kho";
    }

    public static class Role
    {
        public static string admin = "Admin";
        public static string nhanvien = "Nhân viên";
        public static string quanlykho = "Quản lý kho";
        public static string khachhang = "Khách hàng";
        
    }
}
