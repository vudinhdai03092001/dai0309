<template>
  <main>
     <Toast />
    <div class="container">
      <section
        class="
          section
          register
          min-vh-100
          d-flex
          flex-column
          align-items-center
          justify-content-center
          py-4
        "
      >
        <div class="container">
          <div class="row justify-content-center">
            <div
              class="
                col-lg-4 col-md-6
                d-flex
                flex-column
                align-items-center
                justify-content-center
              "
            >
              <div class="d-flex justify-content-center py-4">
                <a
                  href="index.html"
                  class="logo d-flex align-items-center w-auto"
                >
                  <img src="assets/img/logo.png" alt="" />
                  <span class="d-none d-lg-block">DINHDAI</span>
                </a>
              </div>
              <!-- End Logo -->

              <div class="card mb-3">
                <div class="card-body" style="width: 400px">
                  <div class="pt-4 pb-2">
                    <h5 class="card-title text-center pb-0 fs-4">
                      Đăng ký tài khoản
                    </h5>
                    <p class="text-center small">
                      Nhập thông tin của bạn
                    </p>
                  </div>
                  <form
                    @submit.prevent="handleSubmit(!v$.$invalid)"
                    class="p-fluid"
                    style="width: 350px"
                  >
                    <!-- <h5 class="text-center">Đăng Ký tài khoản</h5> -->
                    <div class="field">
                      <div class="p-float-label">
                        Tên tài khoản
                        <div class="p-inputgroup">
                          <span class="p-inputgroup-addon">
                            <i class="pi pi-user"></i>
                          </span>
                          <InputText
                            id="userName  "
                            placeholder="Username"
                            v-model="v$.userName.$model"
                            :class="{
                              'p-invalid': v$.userName.$invalid && submitted,
                            }"
                          />
                        </div>
                        <label
                          for="userName"
                          :class="{
                            'p-error': v$.userName.$invalid && submitted,
                          }"
                        ></label>
                      </div>
                      <small
                        v-if="
                          (v$.userName.$invalid && submitted) ||
                          v$.userName.$pending.$response
                        "
                        class="p-error"
                        >{{
                          v$.userName.required.$message.replace(
                            "Value",
                            "userName"
                          )
                        }}</small
                      >
                    </div>
                    <div class="field">
                      <div class="p-float-label">
                        Email của bạn
                        <div class="p-inputgroup">
                          <span class="p-inputgroup-addon">@</span>
                          <InputText
                            id="email  "
                            placeholder="Email address"
                            v-model="v$.email.$model"
                            :class="{
                              'p-invalid': v$.email.$invalid && submitted,
                            }"
                          />
                        </div>

                        <label
                          for="email"
                          :class="{ 'p-error': v$.email.$invalid && submitted }"
                        ></label>
                      </div>
                      <small
                        v-if="
                          (v$.email.$invalid && submitted) ||
                          v$.email.$pending.$response
                        "
                        class="p-error"
                        >{{
                          v$.email.required.$message.replace("Value", "email")
                        }}</small
                      >
                    </div>

                    <div class="field">
                      Nhập mật khẩu
                      <span class="p-float-label">
                        <Password
                          toggleMask
                          v-model="v$.password.$model"
                          :class="{
                            'p-invalid': v$.password.$invalid && submitted,
                          }"
                        ></Password>
                        <label
                          for="password"
                          :class="{
                            'p-error': v$.password.$invalid && submitted,
                          }"
                        ></label>
                      </span>
                    </div>
                    <div class="field">
                      Nhập lại mật khẩu
                      <span class="p-float-label">
                        <Password
                          :feedback="false"
                          v-model="v$.confirmPassword.$model"
                          :class="{
                            'p-invalid':
                              v$.confirmPassword.$invalid && submitted,
                          }"
                        ></Password>
                        <label
                          for="confirmPassword"
                          :class="{
                            'p-error': v$.confirmPassword.$invalid && submitted,
                          }"
                        ></label>
                      </span>
                    </div>
                    <Button
                      style="background-color: blue"
                      type="Login"
                      label="Submit"
                      class="mt-2"
                    />
                    <div class="col-12">
                      <p class="small mb-0">
                        Bạn muốn đăng nhập tài khoản?
                        <a href="/Login">Đăng nhập</a>
                      </p>
                    </div>
                  </form>
                </div>
              </div>

              <div class="credits">
                <!-- All the links in the footer should remain intact. -->
                <!-- You can delete the links only if you purchased the pro version. -->
                <!-- Licensing information: https://bootstrapmade.com/license/ -->
                <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/ -->
                Cám ơn bạn đã đến với chúng tôi
                
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  </main>
</template>
<script setup >
import { reactive, ref, onMounted } from "vue";
import { email, required } from "@vuelidate/validators";
import { useVuelidate } from "@vuelidate/core";
import { useRouter } from "vue-router";
import InputNumber from "primevue/inputnumber";
import InputText from "primevue/inputtext";
import Password from "primevue/password";
import Button from "primevue/button";
import { inject } from "vue";
import { useToast } from "primevue/usetoast";
import Toast from "primevue/toast";
const axios = inject("axios");
const router = useRouter();
const toast = useToast();
const state = reactive({

  userName: "",
  password: "",
  confirmPassword: "",
  email: "",
  firstName: "ten",
  lastName: "ho",
  dob: "2022-12-12",
  phoneNumber: "123456",
});
const rules = {
  userName: { required },
  password: { required },
  email: { required },
  firstName: { required },
  lastName: { required },
  dob: { required },
  phoneNumber: { required },
  //   phoneNumber:{required},
  confirmPassword: { required },
};
const submitted = ref(false);

const showMessage = ref(false);
const v$ = useVuelidate(rules, state);

const handleSubmit = (isFormValid) => {
  // if (!isFormValid) {
  //   return;
  // } else {
    // submitted.value = true;
   console.log(state);
   let res =  axios({
      method: "post",
      url: "https://localhost:44396/User",      
      data: state,
    });
  
 // toggleDialog();
  // router.$push("/products");
  // if ((res.data.isSuccessed = true)) {
  //   toast.add({
  //   severity: "success",
  //   summary: "Success Message",
  //   detail: "Đăng nhập thành công thành công.",
  //   life: 3000,
  // });
  // }
  console.log(res.data)
if ((res.data.isSuccessed = true)) {
    toast.add({ severity: 'error', summary: 'Error Message', detail: 'Message Content', life: 3000 });
  }
}

//};
// const toggleDialog = () => {
//   showMessage.value = !showMessage.value;
//};
</script>
