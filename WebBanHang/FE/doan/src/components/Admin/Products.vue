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
import Editor from "primevue/editor";
import Textarea from "primevue/textarea";
const route = useRoute();
const products = ref([]);
const categories = ref([]);
const axios = inject("axios");
const display = ref();
const display1 = ref();
const selectedItem = ref(null);
const toast = useToast();
const FilterBy = ref(null);
let pageSize = ref(1);
let currentPage = ref(0);
let image = ref(null);
let nameProduct = ref(null);
let amount = ref(null);
let price = ref(null);
let oldPrice = ref(null);
let nameSupplier = ref(null);
let describe = ref(null);
let idCategory = ref(null);
let parameter1 = ref(null);
let parameter2 = ref(null);
let parameter3 = ref(null);
let parameter4 = ref(null);
let parameter5 = ref(null);
let parameter6 = ref(null);
let parameter7 = ref(null);
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

onMounted(async () => {
  await getDataCate();
});
const getDataCate = async () => {
  let res = await axios.get(`https://localhost:44396/Category`);
  console.log(res.data);
  categories.value = res.data;
};

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
const handleAddProduct = async () => {
  let payload = {
    nameProduct: nameProduct.value,
    amount: amount.value,
    price: price.value,
    oldPrice: oldPrice.value,
    nameSupplier: nameSupplier.value,
    describe: describe.value,
    image: image.value,
    idCategory: idCategory.value,
    parameter1: parameter1.value,
    parameter2: parameter2.value,
    parameter3: parameter3.value,
    parameter4: parameter4.value,
    parameter5: parameter5.value,
    parameter6: parameter6.value,
    parameter7: parameter7.value,
  };
  let res = await axios.post("https://localhost:44396/Product", payload);
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
  if (confirm("Bạn có muốn xóa sản phẩm này không") == true) {
  let res = await axios.delete(`https://localhost:44396/Product/${id}`);
  alert("Bạn muốn xóa sản phẩm không?");
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
    nameProduct: selectedItem.value.nameProduct,
    image: selectedItem.value.image,
    amount: selectedItem.value.amount,
    price: selectedItem.value.price,
    oldPrice: selectedItem.value.oldPrice,
    idCategory: selectedItem.value.idCategory,
    describe: selectedItem.value.describe,
    nameSupplier: selectedItem.value.nameSupplier,
    parameter1: selectedItem.value.parameter1,
    parameter2: selectedItem.value.parameter2,
    parameter3: selectedItem.value.parameter3,
    parameter4: selectedItem.value.parameter4,
    parameter5: selectedItem.value.parameter5,
    parameter6: selectedItem.value.parameter6,
    parameter7: selectedItem.value.parameter7,
  };
  console.log(payload);
  console.log(selectedItem.value.id);
  let res = await axios.put(
    `https://localhost:44396/Product/${selectedItem.value.id}`,
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

const onUpload = () => {
  toast.add({
    severity: "info",
    summary: "Success",
    detail: "File Uploaded",
    life: 3000,
  });
};
</script>
<template>
  <Header :getData="getData" v-model:FilterBy="FilterBy" />

  <Sidebar />
  <main id="main">
    <Toast />
    <Dialog
      header="Thêm sản phẩm"
      v-model:visible="display"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '80vw' }"
    >
      <div class="p-float-label" style="width: 550px; float: left">
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="nameProduct">Tên sản phẩm</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="nameProduct"
            type="text"
            v-model="nameProduct"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="nameProduct">Tên loại sản phẩm</label>
          <Dropdown
            style="border: 1px solid black; width: 350px"
            class="divide-black"
            v-model="idCategory"
            :options="categories"
            optionLabel="nameCategory"
            optionValue="id"
            placeholder="select"
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
            id="image"
            type="text"
            v-model="image"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="amount">Số lượng</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="image"
            type="text"
            v-model="amount"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="describle">Mô tả sản phẩm </label>

          <Textarea
            v-model="describe"
            rows="2"
            cols="30"
            style="border: 1px solid black"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="price">Giá hiện tại </label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="price"
            type="text"
            v-model="price"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="oldPrice">Giá cũ </label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="oldPrice"
            type="text"
            v-model="oldPrice"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="nameSupplier">Tên nhà cung cấp</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="nameSupplier"
            type="text"
            v-model="nameSupplier"
          />
        </div>
      </div>
      <div class="p-float-label" style="width: 600px; float: left">
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 100px; width: 500px"
        >
          <label for="nameSupplier">Thông số 1</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="nameSupplier"
            type="text"
            v-model="parameter1"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 100px; width: 500px"
        >
          <label for="nameSupplier">Thông số 2</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="nameSupplier"
            type="text"
            v-model="parameter2"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 100px; width: 500px"
        >
          <label for="nameSupplier">Thông số 3</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="nameSupplier"
            type="text"
            v-model="parameter3"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 100px; width: 500px"
        >
          <label for="nameSupplier">Thông số 4</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="nameSupplier"
            type="text"
            v-model="parameter4"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 100px; width: 500px"
        >
          <label for="nameSupplier">Thông số 5</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="nameSupplier"
            type="text"
            v-model="parameter5"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 100px; width: 500px"
        >
          <label for="nameSupplier">Thông số 6</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="nameSupplier"
            type="text"
            v-model="parameter6"
          />
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 100px; width: 500px"
        >
          <label for="nameSupplier">Thông số 7</label>
          <InputText
            style="border: 1px solid black"
            class="divide-black"
            id="nameSupplier"
            type="text"
            v-model="parameter7"
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
        <Button label="ADD" icon="pi pi-check" @click="handleAddProduct" />
      </template>
    </Dialog>

    <Dialog
      header="Edit Product"
      style="width: 300px !important"
      v-model:visible="display1"
      :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
      :style="{ width: '80vw' }"
    >
      <div class="p-float-label" style="width: 550px; float: left">
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <!-- <div class="p-float-label" style="margin-top: 10px; padding-left: 100px"> -->
          <label for="nameProduct">Tên sản phẩm </label>
          <div class="field col-12 md:col-8">
            <span class="p-float-label">
              <InputText
                id="nameProduct"
                type="text"
                v-model="selectedItem.nameProduct"
              />
            </span>
          </div>
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="idCategory">Loại sản phẩm</label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <Dropdown
                style="width: 320px"
                v-model="selectedItem.idCategory"
                :options="categories"
                optionLabel="nameCategory"
                optionValue="id"
                placeholder="select"
              />
            </div>
          </div>
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="image">Hình ảnh </label>
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
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="amount">Số lượng </label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="amount"
                type="text"
                v-model="selectedItem.amount"
              />
            </div>
          </div>
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="price">Giá hiện tại </label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="price"
                type="text"
                v-model="selectedItem.price"
              />
            </div>
          </div>
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="oldPrice">Giá cũ </label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="oldPrice"
                type="text"
                v-model="selectedItem.oldPrice"
              />
            </div>
          </div>
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="nameSupplier">Nhà cung cấp</label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="nameSupplier"
                type="text"
                v-model="selectedItem.nameSupplier"
              />
            </div>
          </div>
        </div>
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="describe">Mô tả sản phẩm</label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <!-- <InputText
            class="divide-black"
            id="describe"
            type="text"
            v-model="selectedItem.describe"
          /> -->
              <Textarea v-model="selectedItem.describe" rows="2" cols="30" />
            </div>
          </div>
        </div>
      </div>
      <div class="p-float-label" style="width: 550px; float: left">
        <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="oldPrice">Thông số 1 </label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="oldPrice"
                type="text"
                v-model="selectedItem.parameter1"
              />
            </div>
          </div>
        </div>
         <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="oldPrice">Thông số 2 </label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="oldPrice"
                type="text"
                v-model="selectedItem.parameter2"
              />
            </div>
          </div>
        </div>
         <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="oldPrice">Thông số 3</label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="oldPrice"
                type="text"
                v-model="selectedItem.parameter3"
              />
            </div>
          </div>
        </div>
         <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="oldPrice">Thông số 4 </label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="oldPrice"
                type="text"
                v-model="selectedItem.parameter4"
              />
            </div>
          </div>
        </div>
         <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="oldPrice">Thông số 5 </label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="oldPrice"
                type="text"
                v-model="selectedItem.parameter5"
              />
            </div>
          </div>
        </div>
         <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="oldPrice">Thông số 6 </label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="oldPrice"
                type="text"
                v-model="selectedItem.parameter6"
              />
            </div>
          </div>
        </div>
         <div
          class="p-float-label"
          style="margin-top: 10px; padding-left: 150px; width: 500px"
        >
          <label for="oldPrice">Thông số 7 </label>
          <div class="field col-12 md:col-8">
            <div class="p-float-label">
              <!-- <label for="image">Image </label> -->
              <InputText
                class="divide-black"
                id="oldPrice"
                type="text"
                v-model="selectedItem.parameter7"
              />
            </div>
          </div>
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
        <h1>Bảng sản phẩm</h1>
      </div>
      <!-- End Page Title -->
      <section class="section">
        <div class="row">
          <div class="col-lg-12">
            <div class="card">
              <div class="card-body">
                <Button @click="handleClick" label="Thêm sản phẩm" />
                <p></p>
                <!-- Table with stripped rows -->
                <DataTable :value="products" responsiveLayout="scroll">
                  <Column
                    class="text-2xl"
                    field="nameProduct"
                    header="Tên sản phẩm"
                  ></Column>

                  <Column class="text-2xl" field="price" header="Giá">
                    <template #body="{ data }">
                      {{ VND.format(data.price) }}
                    </template>
                  </Column>
                  <Column class="text-2xl" field="oldPrice" header="Giá cũ">
                    <template #body="{ data }">
                      {{ VND.format(data.oldPrice) }}
                    </template>
                  </Column>
                  <Column
                    class="text-2xl"
                    field="nameSupplier"
                    header="Nhà cung cấp"
                  ></Column>

                  <Column
                    class="text-2xl"
                    field="describe"
                    header="Mô tả"
                  ></Column>

                  <Column
                    class="text-2xl"
                    field="amount"
                    header="Số Lượng"
                  ></Column>
                  <Column class="text-2xl" field="image" header="Image">
                    <template #body="slotProps">
                      <img
                        style="width: 50px; height: 60px"
                        :src="slotProps.data.image"
                      />
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