<script setup>
import Header from "../components/Header.vue";
import Footer from "../components/Footer.vue";

import { onMounted, computed } from "vue";
import { ref } from "vue";
import { inject } from "vue";
import dayjs from "dayjs";
import relativeTime from "dayjs/plugin/relativeTime";
import { useRoute } from "vue-router";
dayjs.extend(relativeTime);
import Dialog from "primevue/dialog";
import Button from "primevue/button";
import Image from 'primevue/image';
const axios = inject("axios");
const count = ref(0);
const comments = ref([]);
const submitting = ref(false);
const value = ref("");
const route = useRoute();
const product = ref({});
const sanphamLienQuan = ref({});
const selectedItem = ref(null);
const cartItems = ref([]);
const VND = new Intl.NumberFormat("vi-VN", {
  style: "currency",
  currency: "VND",
});

let id = computed(() => {
  return route.params.id;
});
const handleSubmit = () => {
  if (!value.value) {
    return;
  }
  submitting.value = true;
  setTimeout(() => {
    submitting.value = false;
    comments.value = [
      {
        author: "Customer ",
        // avatar: "https://joeschmoe.io/api/v1/random",
        content: value.value,
        datetime: dayjs().fromNow(),
      },
      ...comments.value,
    ];
    value.value = "";
  }, 1000);
};
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
onMounted(() => {
  console.log(`the component is now mounted.`);
  axios
    .get(`https://localhost:44396/Product/Get/${id.value}`)
    .then((response) => {
      console.log(response.data);
      product.value = response.data;
      axios
        .get(
          `https://localhost:44396/Category/Getallproducts/${response.data.idCategory}`
        )
        .then((response) => {
          console.log(response.data);
          sanphamLienQuan.value = response.data;
        });
    });
  cartItems.value = JSON.parse(localStorage.getItem("cart"));
  console.log("cart", cartItems.value);
});
const display = ref();
function handleClick() {
  display.value = true;
}
</script>
<template>
  <Header />
  <div class="content-wraper">
    <div class="container">
      <div class="row single-product-area">
        <div class="col-lg-5 col-md-6">
          <!-- Product Details Left -->
          <div class="product-details-left">
            <div class="product-details-images slider-navigation-1">
              <div class="lg-image">
                <!-- <img v-bind:src="'/' + product.image" alt="product image" /> -->
                <Image v-bind:src="'/' + product.image" alt="Image" width="250" preview />

              </div>
            </div>
          </div>
          <br>
          <br><br><br>
          <div>{{product.describe}}</div>
          <!--// Product Details Left -->
        </div>

        <div class="col-lg-7 col-md-6">
          <div class="product-details-view-content sp-normal-content pt-60" >
            <div class="product-info" >
            <div style="width:50%;float:left">
              <h2>Tên sản phẩm : {{ product.nameProduct }}</h2>
              <span class="product-details-ref">Nhà cung cấp: {{
                product.nameSupplier
              }}</span>
              <div class="rating-box pt-20">
                <ul class="rating rating-with-review-item">
                  <li><i class="fa fa-star-o"></i></li>
                  <li><i class="fa fa-star-o"></i></li>
                  <li><i class="fa fa-star-o"></i></li>
                  <li class="no-star"><i class="fa fa-star-o"></i></li>
                  <li class="no-star"><i class="fa fa-star-o"></i></li>
                  
                </ul>
              </div>
            
              <div class="price-box pt-20">
                <span class="new-price new-price-2" style="text-decoration: line-through;color:gray;font-size:20px"
                  >Giá cũ: {{ VND.format(product.oldPrice) }}
                </span><br>
                <span class="new-price new-price-2"
                  >Giá mới: {{ VND.format(product.price) }}
                </span>
                
              </div>
              <div class="detailproduct-information-amount">
                <div class="detailproduct-amount-cart">
                  <button
                    class="detailproduct-amount-addcart"
                    @click="addtocart(product)"
                  >
                    Thêm Vào Giỏ Hàng
                  </button>
               


                </div>
              </div>
              <div class="product-additional-info">
                <div class="product-social-sharing">
                  <ul>
                    <li class="facebook">
                      <a href="#"><i class="fa fa-facebook"></i>Facebook</a>
                    </li>
                    <li class="twitter">
                      <a href="#"><i class="fa fa-twitter"></i>Twitter</a>
                    </li>
                    
                    <li class="instagram">
                      <a href="#"><i class="fa fa-instagram"></i>Instagram</a>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
             <div style="width:50%;float:left;">
              - {{product.parameter1}}<hr>
              - {{product.parameter2}}<hr>
              - {{product.parameter3}}<hr>
              - {{product.parameter4}}<hr>
              - {{product.parameter5}}<hr>
              - {{product.parameter6}}<hr>
              - {{product.parameter7}}
             </div>
             
            </div>
           
          </div>
           
        </div>
      </div>
    </div>
  </div>
  <!-- content-wraper end -->
  <!-- Begin Product Area -->
  <div class="product-area pt-40">
    <div class="container">
      <div class="row">
        <div class="col-lg-12">
          <div class="li-product-tab">
            <ul class="nav li-product-menu">
              <li>
                <a class="active" data-toggle="tab" href="#description"
                  ><span>Bình luận</span></a
                >
              </li>
            </ul>
          </div>
          <!-- Begin Li's Tab Menu Content Area -->
        </div>
      </div>
      <div class="tab-content">
        <a-list
          v-if="comments.length"
          :data-source="comments"
          :header="`${comments.length} ${
            comments.length > 1 ? 'replies' : 'reply'
          }`"
          item-layout="horizontal"
        >
          <template #renderItem="{ item }">
            <a-list-item>
              <a-comment
                :author="item.author"
                :avatar="item.avatar"
                :content="item.content"
                :datetime="item.datetime"
              />
            </a-list-item>
          </template>
        </a-list>
        <a-comment>
          <!-- <template #avatar>
              <a-avatar
                src="https://joeschmoe.io/api/v1/random"
                alt="Han Solo"
              />
            </template> -->
          <template #content>
            <a-form-item>
              <a-textarea v-model:value="value" :rows="4" />
            </a-form-item>
            <a-form-item>
              <a-button
                html-type="submit"
                :loading="submitting"
                type="primary"
                @click="handleSubmit"
                style="
                  background-color: #4b9af3;
                  border: 1px solid #378cee;
                  color: white;
                "
              >
                Add Comment
              </a-button>
            </a-form-item>
          </template>
        </a-comment>
      </div>
    </div>
  </div>
  <!-- Product Area End Here -->
  <!-- Begin Li's Laptop Product Area -->
  <section class="product-area li-laptop-product pt-30 pb-50">
    <div class="container">
      <div class="row">
        <!-- Begin Li's Section Area -->
        <div class="col-lg-12">
          <div class="li-section-title">
            <h2>
              <span>Sản phẩm tương tự</span>
            </h2>
          </div>
          <div class="row">
            <div class="product-active owl-carousel">
              <div
                class="col-lg-12"
                style="width: 213px; float: left"
                v-for="item in sanphamLienQuan"
                :key="item.code"
              >
                <!-- single-product-wrap start -->
                <div class="single-product-wrap">
                 
                  <div class="product-image" style="height: 200px; display: flex; align-items: center">
                    <Image v-bind:src="'/' + item.image" alt="Image" width="190" preview />
                  </div>
                  <div class="product_desc">
                    <div class="product_desc_info">
                      <div class="product-review">
                        <h5 class="manufacturer">
                          <a href="shop-left-sidebar.html">{{
                            item.nameSupplier
                          }}</a>
                        </h5>
                        <div class="rating-box">
                          <ul class="rating">
                            <li><i class="fa fa-star-o"></i></li>
                            <li><i class="fa fa-star-o"></i></li>
                            <li><i class="fa fa-star-o"></i></li>
                            <li class="no-star">
                              <i class="fa fa-star-o"></i>
                            </li>
                            <li class="no-star">
                              <i class="fa fa-star-o"></i>
                            </li>
                          </ul>
                        </div>
                      </div>
                      <h4>
                        <li>
                          <router-link
                            class="product_name"
                            style="text-decoration: none"
                            :to="`/ProductDetail/${item.id}`"
                            >{{ item.nameProduct }}</router-link
                          >
                        </li>
                      </h4>
                     <div class="price-box">
                        <span class="new-price"  style="text-decoration: line-through;color:gray;font-size:10px">{{
                          VND.format(item.oldPrice)
                        }}</span><br>
                        <span class="new-price" style="color:red">{{
                          VND.format(item.price)
                        }}</span>
                      </div>
                    </div>
                    <div class="add-actions">
                      <ul class="add-actions-link">
                        <li class="add-cart active">
                          <a @click="addtocart(item)">Add to cart</a>
                        </li>
                        <li>
                          <a class="links-details" href="wishlist.html"
                            ><i class="fa fa-heart-o"></i
                          ></a>
                        </li>
                      </ul>
                    </div>
                  </div>
                </div>
                <!-- single-product-wrap end -->
              </div>
            </div>
          </div>
        </div>
        <!-- Li's Section Area End Here -->
      </div>
    </div>
  </section>
  <Footer />
</template>
