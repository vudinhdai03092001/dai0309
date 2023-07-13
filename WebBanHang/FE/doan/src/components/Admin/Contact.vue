<script setup>
import Footer from "../AdminNew/Footer.vue";
import Header from "../AdminNew/Header.vue";
import Sidebar from "../AdminNew/Sidebar.vue";

import Knob from 'primevue/knob';
import { ref } from 'vue';

const value = ref(60);
</script>
<template>
    <Header />
      <Sidebar />
   
     <main id="main" class="main">

   
      <h1>Liên Hệ </h1>
      <nav>
        <ol class="breadcrumb">
          <li class="breadcrumb-item"><a href="/">Home</a></li>
          <li class="breadcrumb-item">Pages</li>
          <li class="breadcrumb-item active">Liên hệ </li>
        </ol>
      </nav>

    <section class="section contact">

      <div class="row gy-4">

        <div class="col-xl-6">

          <div class="row">
            <div class="col-lg-6">
              <div class="info-box card">
                <i class="bi bi-geo-alt"></i>
                <h3>Địa chỉ</h3>
                <p>Số nhà 12<br>160 đường Thanh Bình, TP Hải Dương</p>
              </div>
            </div>
            <div class="col-lg-6">
              <div class="info-box card">
                <i class="bi bi-telephone"></i>
                <h3>Gọi cho chúng tôi</h3>
                <p>+ 0323437859<br> + 0987345276</p>
              </div>
            </div>
            <div class="col-lg-6">
              <div class="info-box card">
                <i class="bi bi-envelope"></i>
                <h3>Email </h3>
                <p>vuquangdai123@example.com<br>vudinhdai0309@gmail.com</p>
              </div>
            </div>
            <div class="col-lg-6">
              <div class="info-box card">
                <i class="bi bi-clock"></i>
                <h3>Mở cửa</h3>
                <p>thứ 2- Chủ nhật<br>9:00h Sáng - 8:00h Tối</p>
              </div>
            </div>
          </div>

        </div>

     

      </div>

    </section>

  </main> 


      <Footer />
</template>