<script setup>
import Header from "../components/Header.vue";
import Footer from "../components/Footer.vue";

import { onMounted, watch, computed } from "vue";
import { ref } from "vue";
import { inject } from "vue";
import { useRoute } from "vue-router";
import DataTable from "primevue/datatable";
import Column from "primevue/column";
import Button from "primevue/button";
const cartItems = ref([]);
const selectedCart = ref();
const axios = inject("axios");
// const props = defineProps(["addToCart"]);
// props.addToCart;
// console.log(props.addToCart)
const VND = new Intl.NumberFormat("vi-VN", {
  style: "currency",
  currency: "VND",
});
function updateCart(e) { 
  cart.push(e);
  //   price = this.shoppingCartTotal;
}
onMounted(() => {
  cartItems.value = JSON.parse(localStorage.getItem("cart"));
  console.log("cart", cartItems.value);
});
function Tang(id) {
  var index = cartItems.value.findIndex((item) => item.id == id);
  if (index >= 0) {
    cartItems.value[index].quantity += 1;
     
  }
  console.log("id", id);
  localStorage.setItem("cart", JSON.stringify(cartItems.value));
}
function Giam(id) {
  var index = cartItems.value.findIndex((item) => item.id == id);
  if (index >= 0 && cartItems.value[index].quantity >= 1) {
    cartItems.value[index].quantity -= 1;
  }
  console.log("id", id);
  localStorage.setItem("cart", JSON.stringify(cartItems.value));
}

function Xoa(id) {
  var index = cartItems.value.findIndex((item) => item.id == id);
  if (index >= 0) {
    cartItems.value.splice(index, 1);
  }
  localStorage.setItem("cart", JSON.stringify(cartItems.value));
}
watch(selectedCart, (newX) => {
  console.log(`selectedCart is ${newX}`);
  //update local storage
  for (let i = 0; i < cartItems.value.length; i++) {
    cartItems.value[i].isSelectedCart =
      selectedCart.value.find((x) => x.id == cartItems.value[i].id) != null;
  }
  localStorage.setItem("cart", JSON.stringify(cartItems.value));
  for (let i = 0; i < selectedCart.value.length; i++) {
    selectedCart.value[i].isSelectedCart = true;
  }
  localStorage.setItem("selectCart", JSON.stringify(selectedCart.value));
});
const totalProduct = computed(() => {
  return selectedCart.value?.length;
});
const total = computed(() => {
  return selectedCart.value?.length > 0
    ? selectedCart.value
        .map((x) => x.quantity * x.price)
        .reduce((partialSum, a) => partialSum + a, 0)
    : 0;
});
</script>
<template>
  <Header />
  <div class="Shopping-cart-area pt-60 pb-60">
    <div class="container">
      <div class="row">
        <div class="col-12">
          <form action="#">
            <div class="table-content table-responsive">
              <DataTable
                :value="cartItems"
                responsiveLayout="scroll"
                v-model:selection="selectedCart"
                style="font-size: 15px"
              >
                <Column
                  selectionMode="multiple"
                  style="width: 3rem"
                  :exportable="false"
                ></Column>
                <Column :exportable="false" header=" Hình Ảnh">
                  <template #body="slotProps">
                    <img
                      :src="slotProps.data.image"
                      alt="a"
                      class="img"
                      style="width: 50px; height: 50px"
                    /> </template
                ></Column>
                <Column field="nameProduct" header="Sản Phẩm"></Column>
                <Column field="price" header="Đơn Giá"></Column>
                <Column :exportable="false" style="min-width: 8rem" header="Số Lượng">
                  <template #body="slotProps">
                    <div class="detailproduct-amount-small-text">
                      <button class="btn-amount" @click="Giam(slotProps.data.id)">
                        -
                      </button>
                      <!-- <input class="ip-amount" aria-valuenow="{{count}}" value="1"> -->
                      <div class="ip-amount">{{ slotProps.data.quantity }}</div>
                      <!-- <InputNumber v-model="item.quantity" /> -->
                      <button class="btn-amount" @click="Tang(slotProps.data.id)">
                        +
                      </button>
                    </div>
                  </template>
                </Column>
                <!-- <Column field="money" header="Số Tiền"></Column> -->
                <Column :exportable="false" style="min-width: 8rem" header="Số Tiền">
                  <template #body="slotProps">
                    <div>{{ slotProps.data.quantity * slotProps.data.price }}</div>
                  </template>
                </Column>
                <Column :exportable="false" style="min-width: 8rem" header="Xóa">
                  <template #body="slotProps">
                    <Button
                      icon="pi pi-trash"
                      class="p-button-rounded p-button-danger btn-delete-cart"
                      @click="Xoa(slotProps.data.id)"
                    />
                  </template>
                </Column>
              </DataTable>
            </div>
            <div class="row">
              <div class="col-12">
                <div class="coupon-all">
                  <div class="coupon">
                    <input
                      id="coupon_code"
                      class="input-text"
                      name="Soluong"
                      value=""
                      placeholder="Coupon code"
                      type="text"
                    />
                    <input
                      class="button"
                      name="apply_coupon"
                      value="Áp dụng"
                      type="submit"
                    />
                  </div>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-5 ml-auto">
                <div class="cart-page-total">
                  <h2>Tổng giỏ hàng</h2>
                  <ul>
                    <li>
                      Tổng sản phẩm :<span>{{ totalProduct }}</span>
                    </li>
                    <li>
                      Tổng tiền<span> {{ total }}</span>
                    </li>
                  </ul>
                  <router-link to="/checkout">Checkout</router-link>
                </div>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
  <Footer />
</template>
