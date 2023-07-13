<script setup>
import Header from "../components/Header.vue";
import Footer from "../components/Footer.vue";
import { onMounted } from "vue";
import { ref } from "vue";
import { inject } from "vue";
const blog = ref({});
const axios = inject("axios");
let currentPage = ref(0);
let pageSize = ref(10);
import Paginator from "primevue/paginator";
import Image from "primevue/image";
onMounted(async () => {
  await getData();
});
const getData = async () => {
  let res = await axios.get(
    `https://localhost:44396/Blog/${currentPage.value}`
  );
  console.log(res.data);
  blog.value = res.data;
};
async function currentPageChange(e) {
  console.log("e", e);
  currentPage.value = e.page;
  await getData();
}
</script>
<template>
  <Header />

  <div class="li-main-blog-page pt-60 pb-55">
    <div class="container">
      <div class="row">
        <!-- Begin Li's Main Content Area -->
        <div class="col-lg-12">
          <div class="row li-main-content">
            <div
              class="col-lg-4 col-md-6"
              v-for="item in blog"
              :key="item.code"
            >
              <div class="li-blog-single-item pb-25">
                <div class="li-blog-banner">
                  <Image :src="item.image" alt="Image" width="300" preview />
                </div>
                <div class="li-blog-content">
                  <div class="li-blog-details">
                    <h3 class="li-blog-heading pt-25">
                    
                       <router-link
                            
                            style="text-decoration: none"
                            :to="`/BlogDetail/${item.id}`"
                            >{{ item.nameBlog }}</router-link
                          >
                    </h3>
                    <div class="li-blog-meta">
                      <a class="author" href="#"
                        ><i class="fa fa-user"></i>Admin</a
                      >
                      
                      <a class="post-time" href="#"
                        ><i class="fa fa-calendar"></i>6/6/20232</a
                      >
                    </div>
                    <p>
                    {{item.describe1}}
                    </p>
                      <router-link
                            class="read-more"
                            style="text-decoration: none"
                            :to="`/BlogDetail/${item.id}`"
                            >read more ...</router-link
                          >
                    
                  </div>
                </div>
              </div>
            </div>

            <!-- Begin Li's Pagination Area -->
            <div class="col-lg-12">
              <div class="li-paginatoin-area text-center pt-25">
                <div class="row">
                  <div class="col-lg-12">
                    <Paginator
                      style="width: 1000px"
                      :rows="pageSize"
                      :totalRecords="200"
                      :rowsPerPageOptions="[10, 20, 30]"
                      @page="currentPageChange"
                    ></Paginator>
                  </div>
                </div>
              </div>
            </div>
            <!-- Li's Pagination End Here Area -->
          </div>
        </div>
        <!-- Li's Main Content Area End Here -->
      </div>
    </div>
  </div>
  <Footer />
</template>