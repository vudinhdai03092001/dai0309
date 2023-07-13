<script setup>
import Header from "../components/Header.vue";
import Footer from "../components/Footer.vue";
// import Layout from "../components/Layout.vue";
import InputText from "primevue/inputtext";
import InputNumber from "primevue/inputnumber";
import DataTable from "primevue/datatable";
import Column from "primevue/column";
import Button from "primevue/button";
import Toast from "primevue/toast";
import { useToast } from "primevue/usetoast";
import { onMounted, computed, watch } from "vue";
import { ref } from "vue";
import { inject } from "vue";

const axios = inject("axios");
const selectedCart = ref();
const toast = useToast();
onMounted(() => {
  selectedCart.value = JSON.parse(localStorage.getItem("selectCart"));
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
const handleAddDonHang = async () => {
  let payload = {
    donhang: {
       id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      nameCustomer: nameCustomer.value,
      address: address.value,
      numberPhone: numberPhone.value,
      note: "new",
      status: 1,
      total: 0,
    },
    donDatHang: [],
  };
  const chitietddh = ref([]);
  selectedCart.value.map((x) => {
    const chitiet = {
      idProduct: x.id,
      quantity: x.quantity,
      price: x.price,
      total: x.quantity * x.price,
    };
    payload.donDatHang.push(chitiet);
  });
  console.log(payload);
  let res = await axios.post("https://localhost:44396/DatHang/TaoHoaDon", payload);
   toast.add({severity:'success', summary: 'Success Message', detail:'Đặt hàng thành công.', life: 3000});
};
</script>
<template>
  <Header />

  <div class="checkout-area pt-60 pb-30">
       <Toast />
    <div class="container">
      <div class="row">
        <div class="col-lg-5 col-12">
          <form action="#">
            <div class="checkbox-form">
              <h3>Chi tiết hóa đơn</h3>
              <div class="row">
                <div class="col-md-12">
                  <div class="checkout-form-list">
                    <label>Họ và tên <span class="required">*</span></label>
                     <InputText
              id="nameCustomer"
              type="text"
              v-model="nameCustomer"
              class="input_kh"
            />
                  </div>
                </div>

                <div class="col-md-12">
                  <div class="checkout-form-list">
                    <label>Số điện thoại</label>
                      <InputText
              id="numberPhone"
              type="number"
              v-model="numberPhone"
              class="input_kh"
            />
                  
                  </div>
                </div>
                <div class="col-md-12">
                  <div class="checkout-form-list">
                    <label>Địa chỉ <span class="required">*</span></label>
                      <InputText
              id="address"
              type="text"
              v-model="address"
              class="input_kh"
            />
                  </div>
                </div>
              </div>
              <div class="different-address">
                <div class="ship-different-title">
                  <h3>
                    <label>Thông tin khách hàng</label>
                  </h3>
                </div>

                <div class="order-notes">
                  <div class="checkout-form-list">
                    <label>Ghi chú</label>
                    <textarea
                      id="checkout-mess"
                      cols="30"
                      rows="10"
                      placeholder="Cám ơn khách hàng đã đến với của hàng chúng tôi!"
                    ></textarea>
                  </div>
                </div>
              </div>
            </div>
          </form>
        </div>
        <div class="col-lg-7 col-15">
          <div class="your-order">
            <h3>Sản phẩm bạn chọn</h3>
            <div class="your-order-table table-responsive">
              <table class="table">
                <DataTable
                  :value="selectedCart"
                  responsiveLayout="scroll"
                  style="font-size: 15px"
                >
                  <Column :exportable="false" header="Hình Ảnh">
                    <template #body="slotProps">
                      <img
                        :src="slotProps.data.image"
                        alt="a"
                        class="img_pkmt"
                        style="width: 50px; height: 60px"
                      /> </template
                  ></Column>
                  <Column field="nameProduct" header="Sản Phẩm"></Column>
                  <Column field="price" header="Đơn Giá"></Column>
                  <Column field="quantity" header="Số lượng"></Column>
                  <Column :exportable="false" style="min-width: 8rem" header="Số Tiền">
                    <template #body="slotProps">
                      <div>{{ slotProps.data.quantity * slotProps.data.price }}</div>
                    </template>
                  </Column>
                </DataTable>
              </table>
            </div>
            <div class="payment-method">
              <div class="payment-accordion">
                <div id="accordion">
                  <div class="card">
                    <div class="card-header" id="#payment-2">
                      <h5 class="panel-title">
                        <a
                          class="collapsed"
                          data-toggle="collapse"
                          data-target="#collapseTwo"
                          aria-expanded="false"
                          aria-controls="collapseTwo"
                        >
                          Sản phẩm đã chọn :{{ totalProduct }}
                        </a>
                      </h5>
                    </div>
                  </div>
                  <div class="card">
                    <div class="card-header" id="#payment-3">
                      <h5 class="panel-title">
                        <a
                          class="collapsed"
                          data-toggle="collapse"
                          data-target="#collapseThree"
                          aria-expanded="false"
                          aria-controls="collapseThree"
                        >
                          Tổng tiền : {{ total }}
                        </a>
                      </h5>
                    </div>
                    <div
                      id="collapseThree"
                      class="collapse"
                      data-parent="#accordion"
                    ></div>
                  </div>
                </div>
                <div class="order-button-payment">
                  <div class="col-lg-12 total">
                    <Button
                      label="Đặt hàng"
                      icon="pi pi-check"
                      iconPos="right"
                      class="col-lg-12"
                      style="font-size: 15px"
                      @click="handleAddDonHang"
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <Footer />
</template>
