<script setup>
import Footer from "../AdminNew/Footer.vue";
import Header from "../AdminNew/Header.vue";
import Sidebar from "../AdminNew/Sidebar.vue";

import DataTable from "primevue/datatable";
import Column from "primevue/column";
import Button from "primevue/button";
import Dialog from "primevue/dialog";
import InputText from "primevue/inputtext";
import Dropdown from "primevue/dropdown";
import Paginator from "primevue/paginator";
import { onMounted } from "vue";
import { ref } from "vue";
import { inject } from "vue";
const ChuaXacNhan = ref([]);
const axios = inject("axios");
const DialogUpdate = ref();
let pageSize = ref(1);
let currentPage = ref(0);
function CloseDiagLog() {
  DialogUpdatePKMT.value = false;
}
function ShowDialogEdit(item) {
  DialogUpdate.value = true;
  selectedItem.value = item;
}
onMounted(async () => {
  await Getdata();
});
const Getdata = async () => {
  let res = await axios.get(
    `https://localhost:44396/DatHang/GetAllDonHangDaGiao`,
  );
  console.log(res.data);
  ChuaXacNhan.value = res.data;
};
const selectedItem = ref(null);
const handleCapNhatDonHang = async () => {
  let payload = {
    id : selectedItem.value.id,
    nameCustomer: selectedItem.value.nameCustomer,
    numberPhone: selectedItem.value.numberPhone,
    address: selectedItem.value.address,
    note: selectedItem.value.note,
    status: selectedItem.value.status,
  };
  console.log(payload);
  console.log(selectedItem.value.id);
  let res = await axios.put(
    `https://localhost:44396/DatHang/${selectedItem.value.id}`,
    payload
  );
  await Getdata();
  DialogUpdate.value = false;
};
async function currentPageChange(e) {
  console.log("e", e);
  currentPage.value = e.page;
  await getData();
}

const status = ref([

 {
    id: 5,
    name: "Đã giao",
  },

]);
</script>
<template>
    <Header />
    <Sidebar />
      <main id="main" >
<Dialog
      header="Cập nhật đơn hàng"
      v-model:visible="DialogUpdate"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '40vw' }"
    >
      <div>
        <label for="trangThai" style="margin-top: 10px; padding-left: 150px"
          >Trạng thái:</label
        >
        <Dropdown
          v-model="selectedItem.status"
          :options="status"
          optionLabel="name"
          optionValue="id"
          placeholder="Cập nhật trạng thái"
          style="width: 300px; margin-left: 10px"
        />
      </div>
      <br />
      <div>
        <label for="ghiChu" style="margin-top: 10px; padding-left: 150px">Ghi chú:</label>
        <InputText
          id="ghiChu"
          type="text"
          v-model="selectedItem.note"
          style="width: 300px; margin-left: 25px"
        />
      </div>
      <template #footer>
        <Button
          label="No"
          icon="pi pi-times"
          @click="CloseDiagLog"
          class="p-button-text"
        />
        <Button
          label="Update"
          icon="pi pi-check"
          iconPos="right"
          @click="handleCapNhatDonHang"
        />
      </template>
    </Dialog>
    <div class="drow"> 
    <div class="pagetitle">
      <h1>Đơn hàng đã giao</h1>   
    </div>
    <section class="section"  >
      <div class="row">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-body">
   <DataTable :value="ChuaXacNhan" responsiveLayout="scroll">
                <Column field="nameCustomer" header="Tên khách hàng"></Column>
                <Column field="address" header="Địa chỉ"></Column>
                <Column field="numberPhone" header="Số điện thoại"></Column>
                <Column
                  field="nameProduct"
                  header="Tên sản phẩm"
                 
                ></Column>
                <Column field="quantity" header="Số lượng"></Column>
                <Column field="price" header="Giá bán"></Column>
                <Column field="total" header="Thành Tiền"></Column>
                <Column field="status" header="Trạng thái"></Column>
                <Column field="note" header="Ghi chú"></Column>
                <Column
                  :exportable="false"
                  style="min-width: 8rem"
                  header="Cập nhật trạng thái"
                >
                  <template #body="slotProps">
                    <Button
                      icon="pi pi-pencil"
                      class="p-button-rounded p-button-warning mr-2"
                      @click="ShowDialogEdit(slotProps.data)"
                    />
                  </template>
                </Column>
              </DataTable>
            </div>
          </div>
        </div>
      </div>
    </section>
    </div>
<Paginator style="width:1100px"
          :rows="pageSize"
          :totalRecords="200"
          :rowsPerPageOptions="[10, 20, 30]"
          @page="currentPageChange"
        ></Paginator>
  </main>
</template>