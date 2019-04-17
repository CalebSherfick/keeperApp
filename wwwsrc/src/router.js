import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vaults from './views/Vaults.vue'
// @ts-ignore
import Keeps from './views/Keeps.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/vaults',
      name: 'vaults',
      component: Vaults
    },
    {
      path: '/keeps',
      name: 'keeps',
      component: Keeps
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    }
  ]
})
