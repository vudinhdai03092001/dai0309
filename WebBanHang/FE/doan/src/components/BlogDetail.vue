<script setup>
import Header from "../components/Header.vue";
import Footer from "../components/Footer.vue";

import { onMounted, computed } from "vue";
import { ref } from "vue";
import { inject } from "vue";
import { useRoute } from "vue-router";
import Image from 'primevue/image';
const axios = inject("axios");
const route = useRoute();
const blog = ref({});
let id = computed(() => {
  return route.params.id;
});
onMounted(() => {
  console.log(`the component is now mounted.`);
  axios
    .get(`https://localhost:44396/Blog/Get/${id.value}`)
    .then((response) => {
      console.log(response.data);
      blog.value = response.data;    
    });
});
</script>
<template>
<Header />
     <div class="li-main-blog-page pt-60 pb-55">
                <div class="container">
                    <div class="row">
                       
                                <div class="col-lg-12">
                                    <div class="li-blog-single-item pb-40">
                                        <div class="li-blog-gallery-slider slick-dot-style">
                                            
                                            
                                             <Image  :src="blog.image" alt="Image" width="1100" preview />
                                            
                                        </div>
                                        <div class="li-blog-content" style="width:800px;margin-left:150px">
                                            <div class="li-blog-details">
                                                <h3 class="li-blog-heading pt-35"><a href="blog-details.html">{{blog.nameBlog}}</a></h3>
                                                <div class="li-blog-meta">
                                                    <a class="author" href="#"><i class="fa fa-user"></i>Admin</a>
                                                    
                                                    <a class="post-time" href="#"><i class="fa fa-calendar"></i> 6/6/2023</a>
                                                </div>
                                                <p>{{blog.describe1}}</p>
                                                <!-- Begin Blog Blockquote Area -->
                                                <div class="li-blog-blockquote">
                                                    <blockquote>
                                                        <p>{{blog.describe2}}</p>
                                                    </blockquote>
                                                </div>
                                                <!-- Blog Blockquote Area End Here -->
                                                <p>{{blog.describe3}} Thực tế, nền tảng quốc dân Google Maps đã hỗ trợ khả năng tải xuống bản đồ từ lâu. Tính năng mới trên ứng dụng của Apple cũng hoạt động giống như các bản tải xuống ngoại tuyến trong Google Maps.Tính năng này đã được triển khai vào năm 2018 trên ứng dụng gọi video Duo của Google, cho phép bạn để lại tin nhắn video 30 giây nếu ai đó bỏ lỡ cuộc gọi video.</p>
                                               
                                                <div class="li-blog-sharing text-center pt-30">
                                                    <h4>Chia sẻ</h4>
                                                    <a href="#"><i class="fa fa-facebook"></i></a>
                                                    <a href="#"><i class="fa fa-twitter"></i></a>
                                                    <a href="#"><i class="fa fa-pinterest"></i></a>
                                                    <a href="#"><i class="fa fa-google-plus"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                  
                            
                        </div>
                        <!-- Li's Main Content Area End Here -->
                    </div>
                </div>
            </div>
            <Footer />
</template>