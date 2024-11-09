$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44309/api/ProductAPI', 
        method: 'GET',
        success: function (data) {
            if (data.isSuccess) {
                localStorage.setItem('orderData', JSON.stringify(data.result));         
            }
            else
            {
                alert("Failed to load products: " + (data.message || "No message"));
            }
        },
        error: function () {
            alert("Failed to load products due to an error with the request.");
        }
    });
});
function addRow() {
    const savedData = localStorage.getItem('orderData');
    let productDropdown = '<select id="product" class="productSelect">';
    const orderData = JSON.parse(savedData);
    orderData.forEach(product => {        
        productDropdown += `<option value="${product.code}" data-rate="${product.rate}">${product.name}</option>`;
    });
    productDropdown += '</select>';
    $('#productRows').append(`
<tr>
<td>${productDropdown}</td>
<td><input type="number" class="qty" oninput="calculateRow(this)" /></td>
<td><input type="text" class="rate" readonly /></td>
<td><input type="number" class="taxPercent" oninput="calculateRow(this)" /></td>
<td><input type="text" class="taxAmount" readonly /></td>
<td><input type="text" class="grossTotal" readonly /></td>
<td><button type="button" class="removeRowBtn">Remove</button></td>
</tr>
    `);
}

$(document).on('click', '.removeRowBtn', function () {
    $(this).closest('tr').remove();
});

function calculateRow(row) {
    const qty = parseFloat($(row).closest('tr').find('.qty').val()) || 0;
    const rate = parseFloat($(row).closest('tr').find('.rate').val()) || 0;
    const taxPercent = parseFloat($(row).closest('tr').find('.taxPercent').val()) || 0;
    const taxAmount = qty * rate * (taxPercent/100);
    const grossTotal = qty * rate + taxAmount;
    $(row).closest('tr').find('.taxAmount').val(taxAmount.toFixed(2));
    $(row).closest('tr').find('.grossTotal').val(grossTotal.toFixed(2));
}

$(document.body).on('change', '.productSelect', function () {
    const savedData = localStorage.getItem('orderData');
    const selected = $(this).val();
    console.log(selected);
    if (savedData) {
        const orderData = JSON.parse(savedData);
        console.log(orderData);
        const ratetest = $(this).find(':selected').data('rate');
        $(this).closest('tr').find('.rate').val(ratetest);
        calculateRow(this); 
    }
});

function saveData() {
    const orderData = [];
    $('#productRows tr').each(function () {
        const product = $(this).find('.productSelect').val();
        const qty = $(this).find('.qty').val();
        const rate = $(this).find('.rate').val();
        const taxPercent = $(this).find('.taxPercent').val();
        const taxAmount = $(this).find('.taxAmount').val();
        const grossTotal = $(this).find('.grossTotal').val();
        orderData.push({ product, qty, rate, taxPercent, taxAmount, grossTotal });
    });

    $.ajax({
        url: 'https://localhost:44309/api/ProductAPI',  
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(orderData),
        success: function (response) {
            alert('Order Saved Successfully!');
        },
        error: function () {
            alert('Failed to save Order');
        }
    });
}
 
 
  


