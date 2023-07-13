<template>
 
  <main>
    <Toast />
    <div class="container">
      <section
        class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4"
      >
        <div class="container">
          <div class="row justify-content-center">
            <div
              class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center"
            >
              <div class="d-flex justify-content-center py-4">
                <router-link
                  to="/"
                  class="logo d-flex align-items-center w-auto"
                >
                  <img src="assets/img/logo.png" alt="" />
                  <span class="d-none d-lg-block">DINHDAI</span>
                </router-link>
              </div>
              <!-- End Logo -->

              <div class="card mb-3">
                <div class="card-body" style="width: 400px">
                  <div class="pt-4 pb-2">
                    <h5 class="card-title text-center pb-0 fs-4">
                      Đăng nhập tài khoản của bạn
                    </h5>
                    <p class="text-center small">
                      Nhập Tên Tài Khoản và Mật Khẩu
                    </p>
                  </div>
                  <h6>Tên đăng nhập</h6> 
                  <input type="text" v-model="myForm.userName" id="username" style="border: 1px solid black" placeholder="Tên đăng nhập ..."/><br><br>
                    <h6>Mật khẩu của bạn</h6> 
                  <input type="password" v-model="myForm.password" style="border: 1px solid black" placeholder="Mật khẩu ..."/> <br ><br>
                  <!-- <button @click="handleLogin()">Login</button> -->
                  <Button  @click="handleLogin()" label="Đăng Nhập" style="margin-left:120px;"/>

                </div>
              </div>
              
              <div class="credits">
               <div class="col-12">
                <p class="small mb-0">
                  Bạn muốn đăng ký tài khoản?
                  <a href="/register">Đăng ký</a>
                </p>
              </div>
                Cám ơn bạn đã đến với chúng tôi
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  </main>
</template>
<script setup >
import { ref } from "vue";
import axios from "axios";
import { useRouter } from "vue-router";

import Button from 'primevue/button';
const router = useRouter();

const myForm = ref({
  userName: "",
  password: "",
});

const handleLogin = async () => {
  let res = await axios.post("https://localhost:44396/User/authenticate", {
    // await axios.post("/api/auth/user/100", {
    username: myForm.value.userName,
    password: myForm.value.password,
  });
    console.log(res.data);
  if ((res.data.isSuccessed = true)) {
     router.replace("/contact");
  }
};
</script>