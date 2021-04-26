import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Counter from "@/components/Counter.vue";
import FetchData from "@/components/FetchData.vue";
import Country from "@/components/Country.vue";
import CountryDetails from "../components/CountryDetails.vue";
import InsertCountry from "../components/AddCountry.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Counter",
        name: "Counter",
        component: Counter,
    },
    {
        path: "/FetchData",
        name: "FetchData",
        component: FetchData,
    },
    {
        path: "/Country",
        name: "Country",
        component: Country,
    },
    {
        path: "/UpdateCountry",
        name: "UpdateCountry",
        component: CountryDetails,
    },
    {
        path: "/InsertCountry",
        name: "InsertCountry",
        component: InsertCountry,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;