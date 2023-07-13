<script setup>
import Footer from"../AdminNew/Footer.vue"
import Header from "../AdminNew/Header.vue"
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
const axios = inject("axios");
const display = ref();
const display1 = ref();
const selectedItem = ref(null);
const toast = useToast();
// const FilterBy = ref(null);
let pageSize = ref(1);
let currentPage = ref(0);
let namePersonnel = ref(null);
let dob = ref(null);
let address = ref(null);
let numberPhone = ref(null);
let position = ref(null);
let salary = ref(null);
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

});
const getData = async () => {
  let res = await axios.get(
    `https://localhost:44396/Personnel/${currentPage.value}`
  );
  console.log(res.data);
  customer.value = res.data;
};
async function currentPageChange(e) {
  console.log("e", e);
  currentPage.value = e.page;
  await getData();
}
const handleAddProduct = async () => {
  let payload = {
    namePersonnel: namePersonnel.value,
    dob: dob.value,
     address: address.value,
    salary: salary.value,
    numberPhone: numberPhone.value,
    position: position.value,
  };
  let res = await axios.post("https://localhost:44396/Personnel", payload);
toast.add({severity:'success', summary: 'Success Message', detail:'Thêm thành công.', life: 3000});
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
  if (confirm("Bạn có muốn xóa sản phẩm này không") == true) {
  let res = await axios.delete(`https://localhost:44396/Personnel/${id}`);
  alert("Bạn muốn xóa sản phẩm không?");
  toast.add({severity:'success', summary: 'Success Message', detail:'Xóa thành công.', life: 3000});
  await getData();
  }
};
const handleEditProject = async () => {
  let payload = {
    id: selectedItem.value.id,
    namePersonnel: selectedItem.value.namePersonnel,
    dob: selectedItem.value.dob,
    salary: selectedItem.value.salary,
    position: selectedItem.value.position,
    numberPhone: selectedItem.value.numberPhone,
    address: selectedItem.value.address,
  };
  console.log(payload);
  console.log(selectedItem.value.id);
  let res = await axios.put(
    `https://localhost:44396/Personnel/${selectedItem.value.id}`,
    payload
  );
  toast.add({severity:'success', summary: 'Success Message', detail:'Sửa thành công.', life: 3000});
  await getData();
  display1.value = false;
};
</script>

<template>
<Header />
<Sidebar />
     <main id="main" >
 <Toast />
    <Dialog
      header="Thêm Nhân Viên"
      v-model:visible="display"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '40vw' }"
    >
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Tên Nhân viên</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="nameProduct"
          type="text"
          v-model="namePersonnel"
        />
      </div>
       <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Địa chỉ</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="nameProduct"
          type="text"
          v-model="address"
        />
      </div>

      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Ngày sinh</label>
       <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="image"
          type="text"
          v-model="dob"
        />
      </div>
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="amount">SỐ điện thoại</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="image"
          type="text"
          v-model="numberPhone"
        />
      </div>
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="describle">Vị trí công việc</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="describle"
          type="text"
          v-model="position"
        />
      </div>
      
     <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="describle">Mức lương</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="describle"
          type="text"
          v-model="salary"
        />
      </div>
      
      <template #footer>
        <Button
          label="No"
          icon="pi pi-times"
          @click="closeBasic"
          class="p-button-text"
        />
        <Button label="ADD" icon="pi pi-check" @click="handleAddProduct" />
      </template>
    </Dialog>

    <Dialog
      header="Sửa thông tin nhân viên"
      style="width: 300px !important"
      v-model:visible="display1"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '40vw' }"
    >
      <!-- <div class="p-float-label" style="margin-top: 10px; padding-left: 100px"> -->
      <label for="nameProduct" style="font-size: 20px">Tên Nhân viên </label>
      <div class="field col-12 md:col-8">
        <span class="p-float-label">
          <InputText
            id="nameProduct"
            type="text"
            v-model="selectedItem.namePersonnel"
          />
        </span>
      </div>
    <label for="nameProduct" style="font-size: 20px">Địa chỉ </label>
      <div class="field col-12 md:col-8">
        <span class="p-float-label">
          <InputText
            id="nameProduct"
            type="text"
            v-model="selectedItem.address"
          />
        </span>
      </div>
    
      <label for="image" style="font-size: 20px">Ngày Sinh</label>
      <div class="field col-12 md:col-8">
        <div class="p-float-label">
          <!-- <label for="image">Image </label> -->
          <InputText
            class="divide-black"
            id="image"
            type="text"
            v-model="selectedItem.dob"
          />
        </div>
      </div>
      <label for="amount" style="font-size: 20px">Số điện thoại</label>
      <div class="field col-12 md:col-8">
        <div class="p-float-label">
          <!-- <label for="image">Image </label> -->
          <InputText
            class="divide-black"
            id="amount"
            type="text"
            v-model="selectedItem.numberPhone"
          />
        </div>
      </div>
      <label for="price" style="font-size: 20px">Vị trí công việc </label>
      <div class="field col-12 md:col-8">
        <div class="p-float-label">
          <!-- <label for="image">Image </label> -->
          <InputText
            class="divide-black"
            id="price"
            type="text"
            v-model="selectedItem.position"
          />
        </div>
      </div>
      <label for="price" style="font-size: 20px">Mức lương </label>
      <div class="field col-12 md:col-8">
        <div class="p-float-label">
          <!-- <label for="image">Image </label> -->
          <InputText
            class="divide-black"
            id="price"
            type="text"
            v-model="selectedItem.salary"
          />
        </div>
      </div>
      <template #footer>
        <Button
          label="No"
          icon="pi pi-times"
          @click="closeBasic"
          class="p-button-text"
        />
        <Button label="Update" icon="pi pi-pencil" @click="handleEditProject" />
      </template>
    </Dialog>
    <div class="drow"> 
    <div class="pagetitle"> 
      <h1>Bảng Nhân Viên</h1>  
    </div><!-- End Page Title -->
    <section class="section"  >
      <div class="row">
        <div class="col-lg-12">

          <div class="card">
            <div class="card-body">
              
               <Button @click="handleClick" label="Thêm sản phẩm" />
<p></p>
              <!-- Table with stripped rows -->
            <DataTable :value="customer" responsiveLayout="scroll"  >
                    <Column
                      class="text-2xl"
                      field="namePersonnel"
                      header="Tên nhân viên"
                    ></Column>
                  
                    <Column
                      class="text-2xl"
                      field="numberPhone"
                      header="Số diện thoại"
                    ></Column>
                     <Column
                      class="text-2xl"
                      field="dob"
                      header="Ngày sinh"
                    ></Column>
                    <Column
                      class="text-2xl"
                      field="address"
                      header="Địa chỉ"
                    ></Column>
                    <Column
                      class="text-2xl"
                      field="position"
                      header="Vị trí công việc"
                    ></Column>
                      <Column
                      class="text-2xl"
                      field="salary"
                      header="Mức lương"
                    >
                    <template #body="{ data }">
                      {{ VND.format(data.salary) }}
                    </template>
                    </Column>
                    <Column
                      :exportable="false"
                      style="min-width: 8rem"
                      header="Chỉnh sửa"
                    >
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
<Paginator style="width:1100px"
          :rows="pageSize"
          :totalRecords="200"
          :rowsPerPageOptions="[10, 20, 30]"
          @page="currentPageChange"
        ></Paginator>
  </main><!-- End #main -->
</template>