const getRate = function () {
    function Get(id) {
        let url = `getrate/artist/${id}`
        let rating = fetch(url).then(() =>
            getElementById('rating')
            .textContent = rating;)
        debugger;
        

    }

    return {

        Get

    }
   
  


}()