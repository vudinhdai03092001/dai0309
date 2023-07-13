<script setup>
import Header from "../components/Header.vue";
import Footer from "../components/Footer.vue";
import { onMounted, computed } from "vue";
import { ref } from "vue";
import { inject } from "vue";
import { useRoute } from "vue-router";
import Image from "primevue/image";
import Dialog from 'primevue/dialog';
import Button from 'primevue/button';
const axios = inject("axios");
const product = ref({});
const value = ref("");
const display = ref();
const route = useRoute();
const selectedItem = ref(null);
const cartItems = ref([]);
let id = computed(() => {
  return route.params.id;
});
const VND = new Intl.NumberFormat("vi-VN", {
  style: "currency",
  currency: "VND",
});
onMounted(() => {
  console.log(`the component is now mounted.`);
  axios
    .get(`https://localhost:44396/Category/Getallproducts/${id.value}`)
    .then((response) => {
      console.log(response.data);
      product.value = response.data;
    });
});
function addtocart(item) {
  const quantity = ref(1);
  selectedItem.value = item;
  if (localStorage.getItem("cart") == null) {
    cartItems.value.push({
      id: selectedItem.value.id,
      nameProduct: selectedItem.value.nameProduct,
      image: selectedItem.value.image,
      price: selectedItem.value.price,
      quantity: quantity.value,
    });
  } else {
    var index = cartItems.value.findIndex(
      (item) => item.id == selectedItem.value.id
    );
    if (index < 0) {
      cartItems.value.push({
        id: selectedItem.value.id,
        nameProduct: selectedItem.value.nameProduct,
        image: selectedItem.value.image,
        price: selectedItem.value.price,
        quantity: quantity.value,
      });
    } else {
      cartItems.value[index].quantity += 1;
    }
  }
  alert("Đã thêm vào giỏ hàng thành công");
  localStorage.setItem("cart", JSON.stringify(cartItems.value));
}
function handleClick() {
  display.value = true;
}
</script>
<template>

  <div class="body-wrapper">
    <!-- Begin Header Area -->
    <Header />
    <div class="breadcrumb-area">
      <div class="container">
        <div class="breadcrumb-content"></div>
      </div>
    </div>
    <div class="content-wraper pt-60 pb-60">
      <div class="container">
        <div class="row">
          <div class="col-lg-12">
            <!-- Begin Li's Banner Area -->
            
            <div
              class="row product-layout-list"
              v-for="item in product"
              :key="item.id"
            >
              <div class="col-lg-3 col-md-5">
                <div class="product-image">
                  <Image
                    v-bind:src="'/' + item.image"
                    alt="Image"
                    width="230"
                    preview
                  />
                </div>
              </div>
              <div class="col-lg-5 col-md-7">
                <div class="product_desc">
                  <div class="product_desc_info">
                    <div class="product-review">
                      <h5 class="manufacturer">
                        <a href="product-details.html">{{item.nameSupplier}}</a>
                      </h5>
                      <div class="rating-box">
                        <ul class="rating">
                          <li><i class="fa fa-star-o"></i></li>
                          <li><i class="fa fa-star-o"></i></li>
                          <li><i class="fa fa-star-o"></i></li>
                          <li class="no-star"><i class="fa fa-star-o"></i></li>
                          <li class="no-star"><i class="fa fa-star-o"></i></li>
                        </ul>
                      </div>
                    </div>
                    <h4>
                      <router-link
                            class="product_name"
                            style="text-decoration: none"
                            :to="`/ProductDetail/${item.id}`"
                            >{{ item.nameProduct }}</router-link
                          >
                    </h4>
                    <div class="price-box">
                       <span class="new-price" style="color: red">Giá: {{
                                  VND.format(item.price)
                                }}</span>
                    </div>
                    <p>
                     {{item.describe}}
                    </p>
                  </div>
                </div>
              </div>
              <div class="col-lg-4">
                <div class="shop-add-action mb-xs-30">
                  <ul class="add-actions-link">
                    <button
                    class="detailproduct-amount-addcart"
                    @click="addtocart(item)"
                  >
                    Thêm Vào Giỏ Hàng
                  </button>
                    <br>
                 <br>
                
                       <router-link
                           
                            style="text-decoration: none"
                            :to="`/ProductDetail/${item.id}`"
                            ><i class="fa fa-eye">--</i>Quick view</router-link
                          >
                      
              
                   
                  </ul>
                </div>
              </div>
            </div>
            <!-- shop-products-wrapper end -->
          </div>
        </div>
      </div>
    </div>
    <Footer />

    <!-- Quick View | Modal Area End Here -->
  </div>
</template>