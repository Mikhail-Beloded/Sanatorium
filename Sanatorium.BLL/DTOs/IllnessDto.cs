﻿namespace Sanatorium.BLL.DTOs
{
    public class IllnessDto : DtoBase
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public List<VoucherIllnessDto> VoucherIllnesses { get; set; }
    }
}
