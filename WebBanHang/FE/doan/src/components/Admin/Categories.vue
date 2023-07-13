
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
import VueUploadComponent from 'vue-upload-component';
const categories = ref([]);
const axios = inject("axios");
const display = ref();
const display1 = ref();
const selectedItem = ref(null);
const toast = useToast();
// const uploadedFile = ref([]);
// const files = ref([]);
const errors = ref([]);

let pageSize = ref(10);
let currentPage = ref(0);
let image = ref(null);
let nameCategory = ref(null);

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
  let res = await axios.get(`https://localhost:44396/Category/${currentPage.value}`);
  console.log(res.data);
  categories.value = res.data;
};

async function currentPageChange(e) {
  console.log("e", e);
  currentPage.value = e.page;
  await getData();
}
const handleAddProduct = async () => {
  let payload = {
    nameCategory: nameCategory.value,

  };
  let res = await axios.post("https://localhost:44396/Category", payload);
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
  let res = await axios.delete(`https://localhost:44396/Category/${id}`);
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
    nameCategory: selectedItem.value.nameCategory,
    image: selectedItem.value.image,
  };
  console.log(payload);
  console.log(selectedItem.value.id);
  let res = await axios.put(
    `https://localhost:44396/Category/${selectedItem.value.id}`,
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
  axios.get("https://localhost:44396/Category").then((response) => {
    console.log(response.data);
    category.value = response.data;
  });
            toast.add({ severity: 'info', summary: 'Success', detail: 'File Uploaded', life: 3000 });
        }


// function onFileChanged(event) {
//   category.image = event.target.files[0];
// }

//  function onSubmit() {
//   // Thêm các trường dữ liệu vào formData
//   this.formData.append('name', this.product.name);
//   this.formData.append('price', this.product.price);

//   // Nếu có ảnh, thêm ảnh vào formData
//   if (this.product.imageFile) {
//     this.formData.append('image', this.product.imageFile, this.product.imageFile.name);
//   }

//   // Gửi request POST đến server
//   axios.post('https://localhost:44396/api/FileUpload/UploadFile', this.formData, {
//     headers: {
//       'Content-Type': 'multipart/form-data'
//     }
//   })
//   .then(response => {
//     console.log(response);
//   })
//   .catch(error => {
//     console.log(error);
//   });
// }

function onImageUploaded(res) {
      // Handle response from server after upload here
    }
  function  uploadImage() {
      this.$refs.imageUploader.upload()
    }
</script>

<template>
  <Header />
  <Sidebar />
  <main id="main">
    <Toast />
    <Dialog
      header="Thêm loại sản phẩm"
      v-model:visible="display"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '40vw' }"
    >

 
      <template #footer>
        <Button label="No" icon="pi pi-times" @click="closeBasic" class="p-button-text" />
        <Button label="ADD" icon="pi pi-check" @click="uploadImage" />
      </template>
    </Dialog>

    <Dialog
      header="Sửa loại sản phẩm"
      style="width: 300px !important"
      v-model:visible="display1"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '40vw' }"
    >
      <!-- <div class="p-float-label" style="margin-top: 10px; padding-left: 100px"> -->
      <label for="nameCategory" style="font-size: 20px">Tên loại sản phẩm </label>
      <div class="field col-12 md:col-8">
        <span class="p-float-label">
          <InputText id="nameCategory" type="text" v-model="selectedItem.nameCategory" />
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
      <h1>Bảng loại sản phẩm</h1>
    </div>
    <!-- End Page Title -->

    <section class="section" style="width: 1100px">
      <div class="row">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-body">
              <Button @click="handleClick" label="Thêm sản phẩm" />
              <p></p>
              <!-- Table with stripped rows -->
              <DataTable
                :value="categories"
                responsiveLayout="scroll"
                style="width: 1000px"
              >
                <Column
                  class="text-2xl"
                  field="nameCategory"
                  header="Tên loại sản phẩm"
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
  <!-- End #main -->
</template>
