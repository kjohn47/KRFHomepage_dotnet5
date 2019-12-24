using KRFCommon.CQRS.Query;
using KRFHomepage.Domain.CQRS.Translations.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KRFHomepage.App.CQRS.Translations.Query
{
    public class GetAppTranslations : IQuery<TranslationRequest, Dictionary<string, Dictionary<string, string>>>
    {
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> _translations = GenerateTranslation();

        public async Task<IQueryOut<Dictionary<string, Dictionary<string, string>>>> QueryAsync(TranslationRequest request)
        {
            var response = this._translations.GetValueOrDefault(request.LangCode);            
            var result = await Task.Run(() => QueryOut<Dictionary<string, Dictionary<string, string>>>.GenerateResult(response));
            return result;
        }

        private static Dictionary<string, Dictionary<string, Dictionary<string, string>>> GenerateTranslation()
        {
            return new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
            {
                {
                    "PT", new Dictionary<string, Dictionary<string,string>>
                    {
                        {
                            "_generic", new Dictionary<string, string>
                            {
                                { "#(loadingText)", "A Carregar!" },
                                { "#(goBackToHome)", "Voltar para Homepage" },
                                { "#(goBackToHomeToolTip)", "Carregue no botão para retomar para a homepage." },
                                { "#(cardDetails)", "Ver detalhes" }
                            }
                        },
                        {
                            "_tableText", new Dictionary<string, string>
                            {
                                { "#(edit)", "Editar" },
                                { "#(remove)", "Remover" }
                            }
                        },
                        {
                            "_TestPage", new Dictionary<string, string>
                            {
                                { "#(TestPage Title)", "Página de Teste de Componentes" }
                            }
                        },
                        {
                            "_datePicker", new Dictionary<string, string>
                            {
                                { "#(January)", "Janeiro"},
                                {"#(February)", "Fevereiro"},
                                {"#(March)", "Março"},
                                {"#(April)", "Abril"},
                                {"#(May)", "Maio"},
                                {"#(June)", "Junho"},
                                {"#(July)", "Julho"},
                                {"#(August)", "Agosto"},
                                {"#(September)", "Setembro"},
                                {"#(October)", "Outubro"},
                                {"#(November)", "Novembro"},
                                {"#(December)", "Dezembro"},
                                {"#(Mon)", "Seg"},
                                {"#(Tue)", "Ter"},
                                {"#(Wed)", "Qua"},
                                {"#(Thu)", "Qui"},
                                {"#(Fri)", "Sex"},
                                {"#(Sat)", "Sab"},
                                {"#(Sun)", "Dom" }
                            }
                        }
                    }
                },
                {
                    "EN", new Dictionary<string, Dictionary<string,string>>
                    {
                        {
                            "_generic", new Dictionary<string, string>
                            {
                                { "#(loadingText)", "Loading!" },
                                { "#(goBackToHome)", "Go back to Homepage" },
                                { "#(goBackToHomeToolTip)", "Click at the button to return to homepage." },
                                { "#(cardDetails)", "View details" }
                            }
                        },
                        {
                            "_tableText", new Dictionary<string, string>
                            {
                                { "#(edit)", "Edit" },
                                { "#(remove)", "Remove" }
                            }
                        },
                        {
                            "_TestPage", new Dictionary<string, string>
                            {
                                { "#(TestPage Title)", "Component Test Page" }
                            }
                        },
                        {
                            "_datePicker", new Dictionary<string, string>
                            {
                                { "#(January)", "January"},
                                {"#(February)", "February"},
                                {"#(March)", "March"},
                                {"#(April)", "April"},
                                {"#(May)", "May"},
                                {"#(June)", "June"},
                                {"#(July)", "July"},
                                {"#(August)", "August"},
                                {"#(September)", "September"},
                                {"#(October)", "October"},
                                {"#(November)", "November"},
                                {"#(December)", "December"},
                                {"#(Mon)", "Mon"},
                                {"#(Tue)", "Tue"},
                                {"#(Wed)", "Wed"},
                                {"#(Thu)", "Thu"},
                                {"#(Fri)", "Fri"},
                                {"#(Sat)", "Sat"},
                                {"#(Sun)", "Sun" }
                            }
                        }
                    }
                }
            };
        }
    }
}