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
let nameCustomer = ref(null);
let dob = ref(null);
let address = ref(null);
let numberPhone = ref(null);
let gioiTinh = ref(null);

function handleClick() {
  display.value = true;
}

onMounted(async () => {
  await getData();

});
const getData = async () => {
  let res = await axios.get(
    `https://localhost:44396/DatHang/GetAllDonHang/${currentPage.value}`
  );
  console.log(res.data);
  customer.value = res.data;
};
async function currentPageChange(e) {
  console.log("e", e);
  currentPage.value = e.page;
  await getData();
}
</script>

<template>
<Header />
<Sidebar />
     <main id="main" >
 <Toast />

    <div class="drow"> 
    <div class="pagetitle"> 
      <h1>Bảng Khách Hàng</h1>  
    </div><!-- End Page Title -->
    <section class="section"  >
      <div class="row">
        <div class="col-lg-12">

          <div class="card">
            <div class="card-body">
              
              
<p></p>
              <!-- Table with stripped rows -->
            <DataTable :value="customer" responsiveLayout="scroll"  >
                    <Column
                      class="text-2xl"
                      field="nameCustomer"
                      header="Tên Khách hàng"
                    ></Column>
                  
                    <Column
                      class="text-2xl"
                      field="address"
                      header="Địa chỉ"
                    ></Column>
                    <Column
                      class="text-2xl"
                      field="numberPhone"
                      header="Số điện thoại"
                    ></Column>
                    
                    
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