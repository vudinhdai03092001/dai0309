<script setup>
import { onMounted } from "vue";
import { ref } from "vue";
import { inject } from "vue";
const category = ref({});
const axios = inject("axios");

onMounted(() => {
  console.log(`the component is now mounted.`);
  axios.get("https://localhost:44396/Category").then((response) => {
    console.log(response.data);
    category.value = response.data;
  });
});

import Button from "primevue/button";

import InputText from "primevue/inputtext";

const props = defineProps({
  FilterBy: String,
  getData: Object,
});
defineEmits(["update:FilterBy"]);
console.log(props.getData);
</script>

<template>
  <header>
    <!-- Begin Header Top Area -->
    <div class="header-top">
      <div class="container">
        <div class="row">
          <!-- Begin Header Top Left Area -->
          <div class="col-lg-3 col-md-4">
            <div class="header-top-left">
              <ul class="phone-wrap">
                <li>
                  <span>Số điện thoại: (+123) 123 321 345</span>
                </li>
              </ul>
            </div>
          </div>
          <!-- Header Top Left Area End Here -->
          <!-- Begin Header Top Right Area -->
          <div class="col-lg-9 col-md-8">
            <div class="header-top-right">
              <ul class="ht-menu">
                <!-- Begin Setting Area -->
                <li>
                  <div class="ht-setting-trigger"><span>Cài đặt</span></div>
                  <div class="setting ht-setting">
                    <ul class="ht-setting-list">
                      <li><a href="login-register.html">Tài Khoản</a></li>
                      <li><a href="checkout.html">Thanh Toán</a></li>
                      <li><a href="login-register.html">Đăng Nhập</a></li>
                    </ul>
                  </div>
                </li>
                <!-- Setting Area End Here -->
                <!-- Begin Currency Area -->
                <li>
                  <span class="currency-selector-wrapper">Hiện nay :</span>
                  <div class="ht-currency-trigger"><span>VNĐ</span></div>
                </li>
                <!-- Currency Area End Here -->
                <!-- Begin Language Area -->
                <li>
                  <span class="language-selector-wrapper">Ngôn ngữ :</span>
                  <div class="ht-language-trigger"><span>Tiếng Việt</span></div>
                </li>
                <!-- Language Area End Here -->
              </ul>
            </div>
          </div>
          <!-- Header Top Right Area End Here -->
        </div>
      </div>
    </div>
    <!-- Header Top Area End Here -->
    <!-- Begin Header Middle Area -->
    <div class="header-middle pl-sm-0 pr-sm-0 pl-xs-0 pr-xs-0">
      <div class="container">
        <div class="row">
          <!-- Begin Header Logo Area -->
          <div class="col-lg-3">
            <div class="logo pb-sm-30 pb-xs-30">
              <li>
                <router-link to="/">
                  <img src="/src/assets/images/menu/logo/logo5.png" alt="" />
                </router-link>
              </li>
            </div>
          </div>
          <!-- Header Logo Area End Here -->
          <!-- Begin Header Middle Right Area -->
          <div class="col-lg-9 pl-0 ml-sm-15 ml-xs-15">
            <!-- Begin Header Middle Searchbox Area -->
            <!-- <form action="#" class="hm-searchbox">
              <input type="text" placeholder="Nhập sản phẩm tìm kiếm ..." />
              <button class="li-btn" type="submit">
                <i class="fa fa-search"></i>
              </button>
            </form> -->

            <form class="hm-searchbox" action="/timkiem.vue">
              <input
                type="text"
                :value="FilterBy"
                @input="$emit('update:FilterBy', $event.target.value)"
                placeholder="Nhập sản phẩm tìm kiếm ..."
              />
              <Button
                icon="pi pi-search"
                @click="getData"
                iconPos="right"
                style="margin-left: 10px"
              />
            </form>
            <!-- Header Middle Searchbox Area End Here -->
            <!-- Begin Header Middle Right Area -->
            <div class="header-middle-right">
              <ul class="hm-menu">
                <li class="hm-minicart">
                  <div class="hm-minicart-trigger">
                    <router-link to="/cart">
                      <span class="item-icon"> </span>
                    </router-link>
                    <span class="item-text"
                      >Giỏ hàng
                      <span class="cart-item-count">1</span>
                    </span>
                  </div>
                </li>
                <!-- Header Mini Cart Area End Here -->
              </ul>
            </div>
            <!-- Header Middle Right Area End Here -->
          </div>
          <!-- Header Middle Right Area End Here -->
        </div>
      </div>
    </div>
    <!-- Header Middle Area End Here -->
    <!-- Begin Header Bottom Area -->
    <div class="header-bottom header-sticky d-none d-lg-block d-xl-block">
      <div class="container">
        <div class="row">
          <div class="col-lg-12">
            <!-- Begin Header Bottom Menu Area -->
            <div class="hb-menu" style="color: white">
              <nav>
                <ul>
                  <li class="dropdown-holder">
                    <a href="/">Trang chủ</a>
                  </li>
                  <li class="megamenu-holder">
                    <a>Danh Mục</a>
                    <ul class="megamenu hb-megamenu">
                      <li>
                        <p>Danh mục các loại sản phẩm</p>
                        <ul v-for="item in category" :key="item.id">
                          <li>
                            <a :href="`/CategoryDetail/${item.id}`"
                              ><font-awesome-icon icon="fa-solid fa-laptop" />
                              {{ item.nameCategory }}</a
                            >
                          </li>
                        </ul>
                      </li>
                    </ul>
                  </li>

                  <li><router-link to="/blog">Blog</router-link></li>
                  <li><router-link to="/cart">Giỏ hàng</router-link></li>
                  <li><router-link to="/login">Đăng nhập</router-link></li>
                </ul>
              </nav>
            </div>
            <!-- Header Bottom Menu Area End Here -->
          </div>
        </div>
      </div>
    </div>
    <!-- Header Bottom Area End Here -->
    <!-- Begin Mobile Menu Area -->
    <div class="mobile-menu-area d-lg-none d-xl-none col-12">
      <div class="container">
        <div class="row">
          <div class="mobile-menu"></div>
        </div>
      </div>
    </div>
    <!-- Mobile Menu Area End Here -->
  </header>
</template>
