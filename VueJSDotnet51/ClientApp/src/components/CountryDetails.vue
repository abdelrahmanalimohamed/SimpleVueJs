<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<template>
    <div>
        <h3 class="text-center">Edit Country</h3>
        <div class="row">
            <div class="col-md-6">
                <form @submit.prevent="updateCountry">
                    <div class="form-group">
                        <label>Country ID</label>
                        <input type="text" class="form-control" v-model="country.country_id">
                    </div>
                    <div class="form-group">
                        <label>Country Name</label>
                        <input type="text" class="form-control" v-model="country.country_name">
                    </div>

                    <div class="form-group">
                        <label>Region Name</label>
                        <input type="text" class="form-control" v-model="country.region_name">
                    </div>

                    <button type="submit" class="btn btn-primary">Update</button>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        data() {
            return {
                country: {}
            }
        },
        created() {
            axios
                .get(`https://localhost:44350/api/Country/singlecountry/${this.$route.params.id}`)
                .then((res) => {
                    this.country = res.data;
                });
        },
        methods: {
            //updateCountry() {
            //    this.axios
            //        .patch(`http://localhost:8000/api/products/${this.$route.params.id}`, this.product)
            //        .then((res) => {
            //            this.$router.push({ name: 'home' });
            //        });
            //}
        }
    }
</script>