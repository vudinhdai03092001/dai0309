<script setup>
import Footer from "../AdminNew/Footer.vue";
import Header from "../AdminNew/Header.vue";
import Sidebar from "../AdminNew/Sidebar.vue";

import { onMounted } from "vue";
import { ref } from "vue";
import { inject } from "vue";
import Button from "primevue/button";
import Dialog from "primevue/dialog";
import InputText from "primevue/inputtext";
import Column from "primevue/column";
import Dropdown from "primevue/dropdown";

import DataTable from "primevue/datatable";
import MultiSelect from "primevue/multiselect";
import { useField } from "vee-validate";
import Paginator from "primevue/paginator";
import FileUpload from "primevue/fileupload";
import { useToast } from "primevue/usetoast";
import Toast from "primevue/toast";
import { defineComponent } from "vue";
import { useRoute } from "vue-router";
const route = useRoute();
const customer = ref([]);
const products = ref([]);
const hoadonban = ref([]);
const axios = inject("axios");
const display = ref();
const display1 = ref();
const selectedItem = ref(null);
const toast = useToast();
const FilterBy = ref(null);
let pageSize = ref(1);
let currentPage = ref(0);
let idKhachHang = ref(null);
let idProduct = ref(null);
let buyDate = ref(null);
let quantity = ref(null);
let totalPrice = ref(null);
const { errorMessage, value } = useField("name", isRequired);
const VND = new Intl.NumberFormat("vi-VN", {
  style: "currency",
  currency: "VND",
});
function handleClick() {
  display.value = true;
}
function handleEdit(item) {
  display1.value = true;
  selectedItem.value = item;
}
onMounted(async () => {
  await getData();
  // await getDataProduct();
  // await getDataCustomer();
});
onMounted(async () => { 
  await getDataProduct();
  // await getDataCustomer();
});
onMounted(async () => {
   await getDataCustomer();
});

const getDataProduct = async () => {
  let res = await axios.get(`https://localhost:44396/Product`);
  console.log(res.data);
  products.value = res.data;
};
const getDataCustomer = async () => {
  let res = await axios.get(`https://localhost:44396/Customer`);
  console.log(res.data);
  customer.value = res.data;
};
const getData = async () => {
let res = await axios.get(`https://localhost:44396/Hoadonban/${currentPage.value}`);
  console.log(res.data);
  hoadonban.value = res.data;
};
async function currentPageChange(e) {
  console.log("e", e);
  currentPage.value = e.page;
  await getData();
}
const handleAddProduct = async () => {
  let payload = {
    idKhachHang: idKhachHang.value,
    idProduct: idProduct.value,
    buyDate: buyDate.value,
    quantity: quantity.value,
    totalPrice: totalPrice.value,
  };
  let res = await axios.post("https://localhost:44396/Hoadonban", payload);
  toast.add({
    severity: "success",
    summary: "Success Message",
    detail: "Thêm thành công.",
    life: 3000,
  });
  await getData();
  display.value = false;
  // categoryId.value = res.data.id;
  // console.log(categoryId.value);
};
function isRequired(value) {
  if (value && value.trim()) {
    return true;
  }
  return "Please enter the product name";
}
function isRequired1(value) {
  if (value && value.trim()) {
    return true;
  }
  return "Please enter the project name";
}
const { errorMessage1, value: pName } = useField("name", isRequired1);
const deleteProduct = async (id) => {
  console.log(id);
  let res = await axios.delete(`https://localhost:44396/Hoadonban/${id}`);
  alert("Bạn muốn xóa sản phẩm không?");
  toast.add({
    severity: "success",
    summary: "Success Message",
    detail: "Xóa thành công.",
    life: 3000,
  });
  await getData();
};
const handleEditProject = async () => {
  let payload = {
    id: selectedItem.value.id,
    idKhachHang: selectedItem.value.idKhachHang,
    idProduct: selectedItem.value.idProduct,
    buyDate: selectedItem.value.buyDate,
    quantity: selectedItem.value.quantity,
    totalPrice: selectedItem.value.totalPrice,
  };
  console.log(payload);
  console.log(selectedItem.value.id);
  let res = await axios.put(
    `https://localhost:44396/Hoadonban/${selectedItem.value.id}`,
    payload
  );
  toast.add({
    severity: "success",
    summary: "Success Message",
    detail: "Sửa thành công.",
    life: 3000,
  });
  await getData();
  display1.value = false;
};
</script>

<template>
  <Header />
  <Sidebar />
  <main id="main">
    <Toast />
    <Dialog
      header="Thêm Hóa Đơn Bán"
      v-model:visible="display"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '40vw' }"
    >
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Tên Khách Hàng</label>
        <Dropdown
          style="border: 1px solid black; width: 350px"
          class="divide-black"
          v-model="idKhachHang"
          :options="customer"
          optionLabel="nameCustomer"
          optionValue="id"
          placeholder="select"
        />
      </div>

      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Tên Sản Phẩm</label>
        <span class="p-float-label">
                 <Dropdown
          style="border: 1px solid black; width: 350px"
          class="divide-black"
          v-model="idProduct"
          :options="products"
          optionLabel="nameProduct"
          optionValue="id"
          placeholder="select"
        />
                        <!-- <MultiSelect id="multiselect" v-model="idProduct" :options="products" optionLabel="nameProduct" /> -->
        </span>
      </div>
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="amount">Ngày Mua</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="image"
          type="text"
          v-model="buyDate"
        />
      </div>
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="describle">Số Lượng</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="quantity"
          type="text"
          v-model="quantity"
        />
      </div>
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="price">Tổng tiền </label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="price"
          type="text"
          v-model="totalPrice"
        />
      </div>

      <template #footer>
        <Button label="No" icon="pi pi-times" @click="closeBasic" class="p-button-text" />
        <Button label="ADD" icon="pi pi-check" @click="handleAddProduct" />
      </template>
    </Dialog>

    <Dialog
      header="Edit Hóa Đơn Bán"
      style="width: 300px !important"
      v-model:visible="display1"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '40vw' }"
    >
      <!-- <div class="p-float-label" style="margin-top: 10px; padding-left: 100px"> -->
      <label for="nameProduct" style="font-size: 20px">Tên khách hàng </label>
      <div class="field col-12 md:col-8">
        <span class="p-float-label">
        <Dropdown
          style="border: 1px solid black; width: 350px"
          class="divide-black"
          v-model="selectedItem.idKhachHang"
          :options="customer"
          optionLabel="nameCustomer"
          optionValue="id"
          placeholder="select"
        />
        </span>
      </div>

      <label for="image" style="font-size: 20px">Tên sản phẩm</label>
      <div class="field col-12 md:col-8">
        <div class="p-float-label">
          <!-- <label for="image">Image </label> -->
        <Dropdown
          style="border: 1px solid black; width: 350px"
          class="divide-black"
          v-model="selectedItem.idproduct"
          :options="products"
          optionLabel="nameProduct"
          optionValue="id"
          placeholder="select"
        />
        </div>
      </div>
      <label for="amount" style="font-size: 20px">Ngày mua </label>
      <div class="field col-12 md:col-8">
        <div class="p-float-label">
          <!-- <label for="image">Image </label> -->
          <InputText
            class="divide-black"
            id="amount"
            type="text"
            v-model="selectedItem.buyDate"
          />
        </div>
      </div>
      <label for="price" style="font-size: 20px">Số lượng </label>
      <div class="field col-12 md:col-8">
        <div class="p-float-label">
          <!-- <label for="image">Image </label> -->
          <InputText
            class="divide-black"
            id="price"
            type="text"
            v-model="selectedItem.quantity"
          />
        </div>
      </div>
      <label for="oldPrice" style="font-size: 20px">Tổng tiền</label>
      <div class="field col-12 md:col-8">
        <div class="p-float-label">
          <!-- <label for="image">Image </label> -->
          <InputText
            class="divide-black"
            id="oldPrice"
            type="text"
            v-model="selectedItem.totalPrice"
          />
        </div>
      </div>
      <template #footer>
        <Button label="No" icon="pi pi-times" @click="closeBasic" class="p-button-text" />
        <Button label="Update" icon="pi pi-pencil" @click="handleEditProject" />
      </template>
    </Dialog>
    <div class="drow">
      <div class="pagetitle">
        <h1>Bảng Hóa Đơn Bán</h1>
      </div>
      <!-- End Page Title -->
      <section class="section">
        <div class="row">
          <div class="col-lg-12">
            <div class="card">
              <div class="card-body">
                <Button @click="handleClick" label="Thêm hóa đơn bán" />
                <p></p>
                <!-- Table with stripped rows -->
                <DataTable :value="hoadonban" responsiveLayout="scroll">
                  <Column
                    class="text-2xl"
                    field="nameCustomer"
                    header="Tên Khách hàng"
                  ></Column>
                   <Column
                    class="text-2xl"
                    field="nameProduct"
                    header="Tên Sản Phẩm"
                  ></Column>
               
                  <Column class="text-2xl" field="buyDate" header="Ngày Mua"></Column>
                  <Column class="text-2xl" field="quantity" header="Số Lượng"></Column>
                     <Column class="text-2xl" field="totalPrice" header="Tổng tiền"></Column>
                  <Column :exportable="false" style="min-width: 8rem" header="Chỉnh sửa">
                    <template #body="slotProps">
                      <Button
                        icon="pi pi-pencil"
                        class="p-button-rounded p-button-success mr-2"
                        @click="handleEdit(slotProps.data)"
                      />
                      <Button
                        icon="pi pi-times"
                        class="p-button-rounded p-button-danger"
                        @click="deleteProduct(slotProps.data.id)"
                      />
                    </template>
                  </Column>
                </DataTable>
                <!-- End Table with stripped rows -->
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
    <Paginator
      style="width: 1100px"
      :rows="pageSize"
      :totalRecords="200"
      :rowsPerPageOptions="[10, 20, 30]"
      @page="currentPageChange"
    ></Paginator>
  </main>
  <!-- End #main -->
</template>
