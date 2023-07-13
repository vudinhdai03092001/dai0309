import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/register',
      name: 'register',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/RegisterView.vue')
      
    },
    {
      path: '/category',
      name: 'category',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Admin/CategoryView.vue')
      
    },
    {
      path: '/Supplier',
      name: 'Supplier',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Admin/SupplierView.vue')
      
    },
    {
      path: '/contact',
      name: 'contact',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Admin/ContactView.vue')
      
    },
    {
      path: '/Products',
      name: 'Products',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Admin/ProductView.vue')
      
    },
    {
      path: '/Blog',
      name: 'Blog',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/BlogView.vue')
      
    },
    {
      path: '/BlogDetail/:id',
      name: 'BlogDetail',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/BlogDetailView.vue')
      
    },
    {
      path: '/ProductDetail/:id',
      name: 'ProductDetail',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/ProductDetailView.vue')      
    },
    {
      path: '/Cart',
      name: 'Cart',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/CartView.vue')      
    },
    {
      path: '/Login',
      name: 'Login',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/LoginView.vue')      
    },
    {
      path: '/Customer',
      name: 'Customer',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Admin/CustomerView.vue')      
    },
    {
      path: '/Checkout',
      name: 'Checkout',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/CheckoutView.vue')      
    },
    {
      path: '/Hoadonban',
      name: 'Hoadonban',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Admin/HoadonbanView.vue')      
    },
    {
      path: '/Hoadonnhap',
      name: 'Hoadonnhap',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Admin/HoadonnhapView.vue')      
    },
    {
      path: '/Personnel',
      name: 'Personnel',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Admin/PersonnelView.vue')      
    },
    {
      path: '/Blogadmin',
      name: 'Blogadmin',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Admin/BlogView.vue')      
    },
    {
      path: '/DHCacSP',
      name: 'DHCacSP',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/DonHang/DHCacSPView.vue')      
    },
    {
      path: '/DHXacNhan',
      name: 'DHXacNhan',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/DonHang/DHXacNhanView.vue')      
    },
    {
      path: '/DHChuaXacNhan',
      name: 'DHChuaXacNhan',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/DonHang/DHChuaXacNhanView.vue')      
    },
    {
      path: '/DHDaHuy',
      name: 'DHDaHuy',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/DonHang/DHDaHuyView.vue')      
    },
    {
      path: '/DHDangGiao',
      name: 'DHDangGiao',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/DonHang/DHDangGiaoView.vue')      
    },
    {
      path: '/DHDaGiao',
      name: 'DHDaGiao',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/DonHang/DHDaGiaoView.vue')      
    },
    {
      path: '/CategoryDetail/:id',
      name: 'CategoryDetail', 
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/CategoryDetailView.vue')      
    },
    {
      path: '/dangnhap',
      name: 'dangnhap', 
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Dangnhap.vue')      
    },
    {
      path: '/upload',
      name: 'upload', 
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/upload.vue')      
    },
  ]
})

export default router
