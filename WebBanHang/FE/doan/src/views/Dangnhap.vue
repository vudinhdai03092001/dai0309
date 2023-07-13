<template>

 <input type="file" @change="onFileSelected">
 <button @click="onUpload">Upload</button>
</template>
<script setup>
import { ref } from "vue"

let selectedFile=ref(null)
function onFileSelected(event){
 selectedFile= event.target.files[0];
}
function onUpload(){
  const fd= new FormData()
  fd.append('image',fd.selectedFile)
axios.post('https://localhost:44396/api/FileUpload/UploadFile',fd)
.then(res=>{console.log(res)

})
}


const axios = inject("axios");
// import { ref } from "vue";
 import { inject } from "vue";
// let fileName = ref('');
// function uploadImage (e) {
//       e.files = e.currentTarget.files[0]
//       let formData = new FormData()
//       formData.append('img', e.fileName)
//       uploadUserImage(formData)
// }
// function uploadUserImage(formData) {
//       axios.post('https://localhost:44396/api/FileUpload/UploadFile', formData,
//         {
//           headers: {
//             'Content-Type': 'multipart/form-data'
//           }
//         })
//         .then(function (response) {
//           console.log(response)
//         })
//     }
</script>
