<template>
      <!-- ======= Sidebar ======= -->
  <aside id="sidebar" class="sidebar" style="width: 16rem!important;">

    <ul class="sidebar-nav" id="sidebar-nav">
 <li class="nav-item">
        <router-link to= "/blogadmin" class="nav-link collapsed" >
          <i class="bi bi-journal-text"></i><span>Danh sách Blog</span>
        </router-link>       
      </li>
      <li class="nav-item">
        <router-link to="/category" class="nav-link collapsed" >
          <i class="bi bi-grid"></i>
          <span>Bảng loại sản phẩm</span>
        </router-link>
      </li><!-- End Dashboard Nav -->

      <li class="nav-item">
        <router-link to="/products" class="nav-link collapsed" >
          <i class="bi bi-menu-button-wide"></i><span>Bảng sản phẩm</span>
        </router-link>
      </li><!-- End Components Nav -->
      <li class="nav-item">
        <router-link to= "/Customer" class="nav-link collapsed" >
          <i class="bi bi-journal-text"></i><span>Bảng khách hàng</span>
        </router-link>       
      </li><!-- End Forms Nav -->
       <li class="nav-item">
        <router-link to= "/Personnel" class="nav-link collapsed" >
          <i class="bi bi-person"></i><span>Bảng nhân viên</span>
        </router-link>       
      </li>
      <li class="nav-item">
        <router-link to= "/Supplier" class="nav-link collapsed" >
          <i class="bi bi-person"></i><span>Bảng nhà cung cấp</span>
        </router-link>       
      </li>
       <li class="nav-item">
        <a class="nav-link collapsed" data-bs-target="#forms-nav" data-bs-toggle="collapse" href="#">
          <i class="bi bi-journal-text"></i><span>Các đơn hàng</span>
        </a>
        <ul id="forms-nav" class="nav-content collapse " data-bs-parent="#sidebar-nav" >
          <li>
             <router-link to="/DHCacSP" style=" text-decoration: none;" >
              <i class="bi bi-circle"></i><span>Tổng các đơn hàng</span>
            </router-link> 
          </li>
          <li>
             <router-link to="/DHXacNhan" style=" text-decoration: none;" >
              <i class="bi bi-circle"></i><span>Đơn hàng đã xác nhận</span>
            </router-link> 
          </li>
          <li>
             <router-link to="/DHDaHuy"  style=" text-decoration: none;">
              <i class="bi bi-circle"></i><span>Đơn hàng đã hủy</span>
             </router-link> 
          </li>
          <li>
           <router-link to="/DHDangGiao" style=" text-decoration: none;" >
              <i class="bi bi-circle"></i><span>Đơn hàng đang giao</span>
            </router-link>
          </li>
          <li>
            <router-link to="/DHDaGiao" style=" text-decoration: none;" >
              <i class="bi bi-circle"></i><span>Đơn hàng đã giao</span>
            </router-link>
          </li>
        </ul>
      </li><!-- End Forms Nav -->
      <li class="nav-item">
        <router-link to="/Hoadonnhap" class="nav-link collapsed"  >
          <i class="bi bi-card-list"></i><span>Hóa đơn nhập</span>
        </router-link>        
      </li>
    </ul>
  </aside><!-- End Sidebar-->
</template>

