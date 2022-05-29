using System.Windows.Forms;

namespace BookSearcherApp
{
    public abstract class CSVSaver1 : CSVSaver
    {
        public override string[] Titles => new string[]
        {
            "sku",
            "product-id",
            "product-id-type",
            "optional-payment-type-exclusion",
            "merchant_shipping_group_name",
            "price",
            "standard-price-points-percent",
            "minimum-seller-allowed-price",
            "maximum-seller-allowed-price",
            "item-condition",
            "quantity",
            "add-delete",
            "will-ship-internationally",
            "item-note",
            "product-tax-code",
            "fulfillment-center-id",
            "handling-time",
            "batteries_required",
            "are_batteries_included",
            "battery_cell_composition",
            "battery_type",
            "number_of_batteries",
            "battery_weight",
            "number_of_lithium_ion_cells",
            "number_of_lithium_metal_cells",
            "lithium_battery_packaging",
            "lithium_battery_energy_content",
            "lithium_battery_weight",
            "supplier_declared_dg_hz_regulation1",
            "supplier_declared_dg_hz_regulation2",
            "supplier_declared_dg_hz_regulation3",
            "supplier_declared_dg_hz_regulation4",
            "supplier_declared_dg_hz_regulation5",
            "hazmat_united_nations_regulatory_id",
            "safety_data_sheet_url",
            "item_weight",
            "item_volume",
            "flash_point",
            "ghs_classification_class1",
            "ghs_classification_class2",
            "ghs_classification_class3",
            "item_weight_unit_of_measure",
            "item_volume_unit_of_measure",
            "lithium_battery_energy_content_unit_of_measure",
            "lithium_battery_weight_unit_of_measure",
            "battery_weight_unit_of_measure"
        };

        protected CSVSaver1(DataGridView view) : base(view) { }
    }
}
