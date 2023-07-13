import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import PrimeVue from 'primevue/config';
import Dialog from 'primevue/dialog';
import ToastService from 'primevue/toastservice';
import { DatePicker } from 'ant-design-vue';
import Antd from 'ant-design-vue';
// import 'ant-design-vue/dist/antd.css';

import ConfirmationService from 'primevue/confirmationservice';
import ConfirmPopup from 'primevue/confirmpopup';


import './assets/main.css'
import './assets/css.css'
import './assets/css1.css'
import './assets/style.css'
import './assets/style1.css'
import './assets/css/nice-select.css'
import './assets/css/sb-admin-2.css'
import './assets/css/bootstrap.min.css'
import './assets/css/sb-admin-2.min.css'

import 'primevue/resources/themes/saga-blue/theme.css '     //theme
import 'primevue/resources/primevue.min.css '     //core css
import "primeicons/primeicons.css" 
const pinia = createPinia()
const app = createApp(App).use(Antd);
const api = axios.create({
    baseURL: "https://localhost:44320/api"
  });
app.use(pinia)
app.use(router)
app.use(VueAxios, axios)
app.mount('#app')
app.use(VueAxios, api);
window.vueAxios = api;
app.provide('axios', app.config.globalProperties.axios)  // provide 'axios'
app.use(PrimeVue);
app.component('Dialog', Dialog);
app.component('ConfirmPopup', ConfirmPopup);
app.use(ToastService);
app.use(DatePicker);
app.use(ConfirmationService);
const fileUpload = require('express-fileupload');
app.use(fileUpload());

