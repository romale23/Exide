using System;
using System.Web;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Publishing.Navigation;



namespace ExideXChangeNavigation
{
    public class XChangeCustomSiteMapProvder : PortalSiteMapProvider
    {
        public override SiteMapNodeCollection GetChildNodes(SiteMapNode node)
        {
            PortalSiteMapNode pNode = node as PortalSiteMapNode;
            if (pNode != null)
            {
                if (pNode.Type == NodeTypes.Area && pNode.WebId == SPContext.Current.Site.RootWeb.ID)
                {
                    SiteMapNodeCollection nodeColl = base.GetChildNodes(pNode);
                    SiteMapNode childNode = new SiteMapNode(this,
                                                            "&lt;http://www.google.com&gt;", "http://www.google.com",
                                                            "Google");

                    SiteMapNode childNode1 = new SiteMapNode(this,
                                                             "&lt;http://www.bing.com&gt;",
                                                             "http://www.bing.com", "Bing");
                    SiteMapNode childNode2 = new SiteMapNode(this,
                                                             "&lt;http://www.hardocp.com&gt;",
                                                             "http://www.hardocp.com", "hardocp");

                    nodeColl.Add(childNode);

                    SiteMapNodeCollection test = new SiteMapNodeCollection();
                    test.Add(childNode1);
                    test.Add(childNode2);
                    childNode.ChildNodes = test;
                    

                    
                    return nodeColl;
                }
                return base.GetChildNodes(pNode);
            }
            return new SiteMapNodeCollection();
        }
    }
}
