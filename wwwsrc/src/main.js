import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import MQ from 'vue-mq'

Vue.config.productionTip = false

Vue.use(MQ, {
  breakpoints: {
    xs: 575.98,
    sm: 767.98,
    md: 991.98,
    lg: 1199.98
  }
})

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
