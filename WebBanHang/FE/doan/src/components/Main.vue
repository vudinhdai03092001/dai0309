<script setup>
import Header from "../components/Header.vue";
import Footer from "../components/Footer.vue";
import { onMounted, renderList } from "vue";
import { ref } from "vue";
import { inject } from "vue";
import Paginator from "primevue/paginator";
import Image from "primevue/image";
const products = ref([]);
const category = ref({});
const laptop = ref({});
const tivi = ref({});
const camera = ref({});
const phone = ref({});
const axios = inject("axios");
const selectedItem = ref(null);
const cartItems = ref([]);
const VND = new Intl.NumberFormat("vi-VN", {
  style: "currency",
  currency: "VND",
});
onMounted(() => {
  console.log(`the component is now mounted.`);
  axios
    .get(
      "https://localhost:44396/Category/Getallproducts/3fa85f64-5717-4562-b3fc-2c963f66afa2"
    )
    .then((response) => {
      console.log(response.data);
      laptop.value = response.data;
      response.data.splice(5);
    });
  axios
    .get(
      "https://localhost:44396/Category/Getallproducts/cf60195f-041a-4121-9b29-eaf85a953b73"
    )
    .then((response) => {
      console.log(response.data);
      tivi.value = response.data;
      response.data.splice(5);
    });
  axios
    .get(
      "https://localhost:44396/Category/Getallproducts/4c488b94-bd74-40f5-9fb8-b579aaa1fe81"
    )
    .then((response) => {
      console.log(response.data);
      camera.value = response.data;
      response.data.splice(5);
    });
  axios
    .get(
      "https://localhost:44396/Category/Getallproducts/aa44de6a-d329-476e-aa7b-0279f653a26d"
    )
    .then((response) => {
      console.log(response.data);
      phone.value = response.data;
      response.data.splice(5);
    });
  axios.get("https://localhost:44396/Category").then((response) => {
    console.log(response.data);
    category.value = response.data;
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

const FilterBy = ref(null);
let pageSize = ref(1);
let currentPage = ref(0);

const getData = async () => {
  let res = await axios.get(
    `https://localhost:44396/Product/${currentPage.value}`,
    {
      params: {
        FilterBy: FilterBy.value,
      },
    }
  );
  console.log(res.data);
  products.value = res.data;
};
async function currentPageChange(e) {
  console.log("e", e);
  currentPage.value = e.page;
  await getData();
}
onMounted(async () => {
  await getData();
});
</script>

<template>
  <Header :getData="getData" v-model:FilterBy="FilterBy" />
  <div class="slider-with-banner">
    <div class="container">
      <div class="row">
        <!-- Begin Slider Area -->
        <div class="col-lg-8 col-md-8">
          <div class="slider-area">
            <div class="slider-active owl-carousel">
              <div
                class="single-slide align-center-left animation-style-01 bg-3"
              >
                <div class="slider-progress"></div>
                <div class="slider-content">
                  <!-- <h5>Giảm giá <span>-10% Off</span></h5>
                  <h2>Phantom 4 Pro+ Obsidian</h2> -->
                  <h3 style="color: blue">
                    Giá chỉ : <span>18.490.000 vnđ</span>
                  </h3>
                  <div class="default-btn slide-btn">
                    <a
                      class="links"
                      style="
                        background-color: #4a4aff;
                        color: white;
                        text-decoration: none;
                      "
                      href="/"
                      >SHOPPING</a
                    >
                  </div>
                </div>
              </div>
              <!-- Single Slide Area End Here -->
            </div>
          </div>
        </div>

        <!-- Begin Li Banner Area -->
        <!-- <div class="col-lg-4 col-md-4 text-center pt-xs-30">
          <div class="li-banner">
            <a href="#">
              <img src="/src/assets/images/img/mayanh5.jpg" alt="" />
            </a>
          </div>
          <div class="li-banner mt-15 mt-sm-30 mt-xs-30">
            <a href="#">
              <img src="/src/assets/images/img/chuotMT8.jpg" alt="" />
            </a>
          </div>
        </div> -->
        <!-- Li Banner Area End Here -->
      </div>
    </div>
  </div>
  <div class="product-area pt-60 pb-50">
    <div class="container">
      <div class="row">
        <div class="col-lg-12">
          <div class="li-product-tab">
            <ul class="nav li-product-menu">
              <li>
                <a class="active" data-toggle="tab" href="#li-new-product"
                  ><span>Các Sản Phẩm </span></a
                >
              </li>
            </ul>
          </div>
          <!-- Begin Li's Tab Menu Content Area -->
        </div>
      </div>
      <div class="tab-content">
        <div id="li-new-product" class="tab-pane active show" role="tabpanel">
          <div class="row">
            <div class="product-active owl-carousel">
              <div
                class="col-lg-12"
                style="width: 213px; float: left"
                v-for="item in products"
                :key="item.code"
              >
                <!-- single-product-wrap start -->
                <div class="single-product-wrap">
                  <div
                    class="product-image;"
                    style="height: 200px; display: flex; align-items: center"
                  >
                    <!-- <img  :src="item.image" alt="Li's Product Image" /> -->
                    <Image :src="item.image" alt="Image" width="190" preview />
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
      </div>
    </div>
  </div>

  <Paginator
    style="width: 1100px; margin-left: 200px; margin-top: 50px"
    :rows="pageSize"
    :totalRecords="200"
    :rowsPerPageOptions="[10, 20, 30]"
    @page="currentPageChange"
  ></Paginator>
  <!-- Product Area End Here -->
  <!-- Begin Li's Static Banner Area -->
  <div class="li-static-banner">
    <div class="container">
      <div class="row">
        <!-- Begin Single Banner Area -->
        <div class="col-lg-4 col-md-4 text-center">
          <div class="single-banner">
            <a href="#">
              <img
                src="/src/assets/images/slider/4.jpg"
                alt="Li's Static Banner"
              />
            </a>
          </div>
        </div>
        <!-- Single Banner Area End Here -->
        <!-- Begin Single Banner Area -->
        <div class="col-lg-4 col-md-4 text-center pt-xs-30">
          <div class="single-banner">
            <a href="#">
              <img
                src="/src/assets/images/slider/5.jpg"
                alt="Li's Static Banner"
              />
            </a>
          </div>
        </div>
        <!-- Single Banner Area End Here -->
        <!-- Begin Single Banner Area -->
        <div class="col-lg-4 col-md-4 text-center pt-xs-30">
          <div class="single-banner">
            <a href="#">
              <img
                src="/src/assets/images/slider/6.jpg"
                alt="Li's Static Banner"
              />
            </a>
          </div>
        </div>
        <!-- Single Banner Area End Here -->
      </div>
    </div>
  </div>
  <!-- Li's Static Banner Area End Here -->
  <!-- Begin Li's Laptop Product Area -->
  <section class="product-area li-laptop-product pt-60 pb-45">
    <div class="container">
      <div class="row">
        <!-- Begin Li's Section Area -->
        <div class="col-lg-12">
          <div class="li-section-title">
            <h2>
              <span>Laptop</span>
            </h2>
          </div>
          <div class="row">
            <div class="product-active owl-carousel">
              <div
                class="col-lg-12"
                style="width: 213px; float: left"
                v-for="item in laptop"
                :key="item.code"
              >
                <!-- single-product-wrap start -->
                <div class="single-product-wrap">
                  <div class="product-image" style="height: 200px; display: flex; align-items: center">
                    <Image :src="item.image" alt="Image" width="190" preview />
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
  <!-- Li's Laptop Product Area End Here -->
  <!-- Begin Li's TV & Audio Product Area -->
  <section class="product-area li-laptop-product li-tv-audio-product pb-45">
    <div class="container">
      <div class="row">
        <!-- Begin Li's Section Area -->
        <div class="col-lg-12">
          <div class="li-section-title">
            <h2>
              <span>TV & Audio</span>
            </h2>
          </div>
          <div class="row">
            <div class="product-active owl-carousel">
              <div
                class="col-lg-12"
                style="width: 213px; float: left"
                v-for="item in tivi"
                :key="item.code"
              >
                <!-- single-product-wrap start -->
                <div class="single-product-wrap">
                  <div class="product-image" style="height: 200px; display: flex; align-items: center">
                    <Image :src="item.image" alt="Image" width="190" preview />
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
  <!-- Li's TV & Audio Product Area End Here -->
  <!-- Begin Li's Static Home Area -->
  <div class="li-static-home">
    <div class="container">
      <div class="row">
        <div class="col-lg-12">
          <!-- Begin Li's Static Home Image Area -->
          <div class="li-static-home-image">
            <h5 class="text" style="margin-left: 135px">
              Cửa hàng bán thiết bị điện tử DINHDAI
            </h5>
            <h5 class="text" style="top: 180px">
              Sẽ mang đến cho bạn những trải nhiệm tốt nhất.
            </h5>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- Li's Static Home Area End Here -->
  <!-- Begin Li's Trending Product Area -->
  <section class="product-area li-trending-product pt-60 pb-45">
    <div class="container">
      <div class="row">
        <!-- Begin Li's Tab Menu Area -->
        <div class="col-lg-12">
          <div class="li-product-tab li-trending-product-tab">
            <h2>
              <span>Loa Bluetooth</span>
            </h2>
          </div>
          <!-- Begin Li's Tab Menu Content Area -->
          <div class="tab-content li-tab-content li-trending-product-content">
            <div id="home1" class="tab-pane show fade in active">
              <div class="row">
                <div class="product-active owl-carousel">
                  <div
                    class="col-lg-12"
                    style="width: 213px; float: left"
                    v-for="item in phone"
                    :key="item.code"
                  >
                    <!-- single-product-wrap start -->
                    <div class="single-product-wrap">
                      <div class="product-image" style="height: 200px; display: flex; align-items: center">
                        <Image
                          :src="item.image"
                          alt="Image"
                          width="190"
                          preview
                        />
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
          </div>
          <!-- Tab Menu Content Area End Here -->
        </div>
        <!-- Tab Menu Area End Here -->
      </div>
    </div>
  </section>
  <!-- Li's Trending Product Area End Here -->
  <!-- Begin Li's Trendding Products Area -->
  <section
    class="product-area li-laptop-product li-trendding-products best-sellers pb-45"
  >
    <div class="container">
      <div class="row">
        <!-- Begin Li's Section Area -->
        <div class="col-lg-12">
          <div class="li-section-title">
            <h2>
              <span>Tai Nghe</span>
            </h2>
          </div>
          <div class="row">
            <div class="product-active owl-carousel">
              <div
                class="col-lg-12"
                style="width: 213px; float: left"
                v-for="item in camera"
                :key="item.code"
              >
                <!-- single-product-wrap start -->
                <div class="single-product-wrap">
                  <div class="product-image" style="height: 200px; display: flex; align-items: center">
                    <Image :src="item.image" alt="Image" width="190" preview />
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
  <!-- Li's Trendding Products Area End Here -->
</template>
