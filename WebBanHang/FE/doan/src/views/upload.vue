<template>
  <input ref="file" v-on:change="handleFileUpload" type="file" />

  <button @click="submitForm()" class="">UPLOAD</button>
</template> 
<script setup>
// import axios from "axios";
// import { defineComponent,ref } from 'vue'
// export default defineComponent({
//   setup() {

//       const file = ref(null)
//      const handleFileUpload = async() => {
//            // debugger;
//             console.log("selected file",file.value.files)
//             //Upload to server
//         }

// function senddata() {

//      axios.post('https://localhost:44396/api/FileUpload/UploadFile',{
//      file:this.file,

//       }).then(response=>{
//       message=response.data.message;
//       alert(message);

//       });
// }

//     return {
//         senddata,
//         handleFileUpload,
//         file
//     };
// }
// })

import axios from "axios";
import { ref } from "vue";




const file = ref(null);
const handleFileUpload = async () => {
  // debugger;
  console.log("selected file", file.value.files);
  //Upload to server
}
const submitForm = async ()=> {
const FormData = require('form-data')
const axios = require('axios')

const form = new FormData()
form.append("file", fs.createReadStream(file))

await axios.post('https://localhost:44396/api/FileUpload/UploadFile', form, { headers: form.getHeaders() })
  .then(function (response) {
    //handle success
    console.log(response);
  })
  .catch(function (response) {
    //handle error
    console.log(response);
    })
}
</script>