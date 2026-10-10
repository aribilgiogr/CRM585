// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const assignLead = (lead_id) => {
    if(confirm("Emin misiniz?")){
        fetch(`/api/leads/assign/${lead_id}`, {method:"POST",headers:{"content-type":"application/json"}})
        .then(res => res.json())
        .then(data => {
            if(!data.isSuccess){
                console.error(data.errors)
            } else {
                location.reload();
            }
        })
    }
}

const addLeadActivity = (type,lead_id) => {
    if(confirm(`Emin misiniz?`)){
        fetch(`/api/leads/addactivity/${type}/${lead_id}`, {method:"POST",headers:{"content-type":"application/json"}})
        .then(res => res.json())
        .then(data => {
            if(!data.isSuccess){
                console.error(data.errors)
            } else {
                location.reload();
            }
        })
    }
}