COnnect-AzAccount

Select-AzSubscription "Microsoft Azure Sponsorship"

$Location = "westeurope"
$ResourceGroupName = "AddTags"
$TemplateFile = "arm\eventgridsubscription.jsonc"
$TemplateParameterFile = "arm\eventgridsubscription.jgs.parameters.jsonc"
#New-AzResourceGroupDeployment -ResourceGroupName $ResourceGroupName -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParameterFile  -verbose

New-AzSubscriptionDeployment -Location $Location -TemplateFile $TemplateFile -TemplateParameterFile $TemplateParameterFile  -verbose