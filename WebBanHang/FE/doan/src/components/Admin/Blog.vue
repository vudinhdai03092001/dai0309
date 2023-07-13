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

const blog = ref([]);
const axios = inject("axios");
const display = ref();
const display1 = ref();
const selectedItem = ref(null);
const toast = useToast();
const uploadedFile = ref([]);
const files = ref([]);


let pageSize = ref(10);
let currentPage = ref(0);
let image = ref(null);
let nameBlog = ref(null);
let describe1= ref(null);
let describe2= ref(null);
let describe3= ref(null);
const { errorMessage, value } = useField("name", isRequired);
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
  let res = await axios.get(`https://localhost:44396/Blog/${currentPage.value}`);
  console.log(res.data);
  blog.value = res.data;
};

async function currentPageChange(e) {
  console.log("e", e);
  currentPage.value = e.page;
  await getData();
}
const handleAddProduct = async () => {
  let payload = {
    nameBlog: nameBlog.value,
    image: image.value,
    describe1:describe1.value,
    describe2:describe2.value,
    describe3:describe3.value,
  };
  let res = await axios.post("https://localhost:44396/Blog", payload);
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

const deleteProduct = async (id) => {
  console.log(id);
  if (confirm("Bạn có muốn xóa sản phẩm này không") == true) {
  let res = await axios.delete(`https://localhost:44396/Blog/${id}`);
  alert("Bạn muốn xóa sản phẩm");
  toast.add({
    severity: "success",
    summary: "Success Message",
    detail: "Xóa thành công.",
    life: 3000,
  });
  await getData();
  }
};
const handleEditProject = async () => {
  let payload = {
    id: selectedItem.value.id,
    nameBlog: selectedItem.value.nameBlog,
    image: selectedItem.value.image,
    describe1: selectedItem.value.describe1,
     describe2: selectedItem.value.describe2,
      describe3: selectedItem.value.describe3,
  };
  console.log(payload);
  console.log(selectedItem.value.id);
  let res = await axios.put(
    `https://localhost:44396/Blog/${selectedItem.value.id}`,
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
 const onAdvancedUpload = () => {
  axios.get("https://localhost:44396/Blog").then((response) => {
    console.log(response.data);
    category.value = response.data;
  });
            toast.add({ severity: 'info', summary: 'Success', detail: 'File Uploaded', life: 3000 });
        }
</script>
<template>
     <Header />
  <Sidebar />
   <main id="main">
    <Toast />
    <Dialog
      header="Thêm loại Blog"
      v-model:visible="display"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '40vw' }"
    >
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Tiêu đề Blog</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="nameProduct"
          type="text"
          v-model="nameBlog"
        />
      </div>
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Mô tả </label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="nameProduct"
          type="text"
          v-model="describe1"
        />
      </div>
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Nội dung 1</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="nameProduct"
          type="text"
          v-model="describe2"
        />
      </div>
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Nội dung 2</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="nameProduct"
          type="text"
          v-model="describe3"
        />
      </div>
      <div
        class="p-float-label"
        style="margin-top: 10px; padding-left: 150px; width: 500px"
      >
        <label for="nameProduct">Hình ảnh</label>
        <InputText
          style="border: 1px solid black"
          class="divide-black"
          id="nameProduct"
          type="text"
          v-model="image"
        />
        <!-- <input class="form-control" ref="fileInput" type="file" @input="pickFile"> -->
      </div>
      <template #footer>
        <Button label="No" icon="pi pi-times" @click="closeBasic" class="p-button-text" />
        <Button label="ADD" icon="pi pi-check" @click="handleAddProduct" />
      </template>
    </Dialog>

    <Dialog
      header="Chỉnh sửa Blog"
      style="width: 300px !important"
      v-model:visible="display1"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '40vw' }"
    >
      <!-- <div class="p-float-label" style="margin-top: 10px; padding-left: 100px"> -->
      <label for="nameCategory" style="font-size: 20px">Tiêu đề Blog</label>
      <div class="field col-12 md:col-8">
        <span class="p-float-label">
          <InputText id="nameBlog" type="text" v-model="selectedItem.nameBlog   " />
        </span>
      </div>
      <label for="nameCategory" style="font-size: 20px">Mô tả</label>
      <div class="field col-12 md:col-8">
        <span class="p-float-label">
          <InputText id="describe1" type="text" v-model="selectedItem.describe1   " />
        </span>
      </div>
      <label for="nameCategory" style="font-size: 20px">Nội dung 1</label>
      <div class="field col-12 md:col-8">
        <span class="p-float-label">
          <InputText id="describe2" type="text" v-model="selectedItem.describe2   " />
        </span>
      </div>
      <label for="nameCategory" style="font-size: 20px">Nội dung 2</label>
      <div class="field col-12 md:col-8">
        <span class="p-float-label">
          <InputText id="describe3" type="text" v-model="selectedItem.describe3   " />
        </span>
      </div>
      <label for="image" style="font-size: 20px">Hình ảnh </label>
      <div class="field col-12 md:col-8">
        <div class="p-float-label">
          <!-- <label for="image">Image </label> -->
          <InputText
            class="divide-black"
            id="image"
            type="text"
            v-model="selectedItem.image"
          />
        </div>
      </div>
      <template #footer>
        <Button label="No" icon="pi pi-times" @click="closeBasic" class="p-button-text" />
        <Button label="Update" icon="pi pi-pencil" @click="handleEditProject" />
      </template>
    </Dialog>
    <div class="pagetitle">
      <h1>Danh sách blog</h1>
    </div>
    <!-- End Page Title -->

    <section class="section" style="width: 1400px">
      <div class="row">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-body">
              <Button @click="handleClick" label="Thêm sản phẩm" />
              <p></p>
              <!-- Table with stripped rows -->
              <DataTable
                :value="blog"
                responsiveLayout="scroll"
                style="width: 1300px"
              >
                <Column
                  class="text-2xl"
                  field="nameBlog"
                  header="Tên tiêu đề"
                ></Column>
                <Column
                  class="text-2xl"
                  field="describe1"
                  header="Mô tả"
                ></Column>
                <Column
                  class="text-2xl"
                  field="describe2"
                  header="Nội dung 1"
                ></Column>
                <Column
                  class="text-2xl"
                  field="describe3"
                  header="Nội dung 2"
                ></Column>
                <Column class="text-2xl" field="Hình ảnh" header="Hình ảnh">
                  <template #body="slotProps">
                    <img style="width: 50px; height: 60px" :src="slotProps.data.image" />
                  </template>
                </Column>
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
    <Paginator
      style="width: 1000px"
      :rows="pageSize"
      :totalRecords="200"
      :rowsPerPageOptions="[10, 20, 30]"
      @page="currentPageChange"
    ></Paginator>
  </main>
</template>