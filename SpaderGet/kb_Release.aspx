<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kb_Release.aspx.cs" Inherits="SpaderGet.kb_Release" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/star.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
</head>
<body>
        <div><label id="lbl_car" runat="server"></label><div id="url" style="display:none" ><%=url%></div>
        <div class="member_right_1">
      <div class="member_right_2">
      </div>
      
      <div class="member_right_9">*为必填项</div>
      <div class="member_right_10">
        <div class="member_right_11"><span>*</span>选择车型</div>
        <div class="member_right_12">
        <select  name="dd_brand" id="dd_brand" class="member_right_13">
        <option>选择品牌</option>
        <option>选择品牌</option>
        <option>选择品牌</option>
        <option>选择品牌</option>
        </select>
        </div>
        <div class="member_right_12">
        <select  name="dd_series" id="dd_series" class="member_right_13">
        <option>选择车系</option>
        <option>选择品牌</option>
        <option>选择品牌</option>
        <option>选择品牌</option>
        </select>
        </div>
        <div class="member_right_14">
        <select  name="dd_car" id="dd_car" class="member_right_13">
        <option value="0">选择车型</option>
        </select>
        </div>
        <div class="member_right_15" id="car_error"></div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11"><span>*</span>口碑类型</div>
        <div class="member_right_16">
        <ul id="T_ID" typeID="">
            <asp:Repeater ID="rep_type" runat="server">
            <ItemTemplate>
            <li><span href="#" class="type" Ttype="<%# Eval("T_ID") %>"><%# Eval("T_Name") %></span></li>
            </ItemTemplate>
            </asp:Repeater>    
        </ul>
     
        </div>
      <div class="member_right_10">
        <div class="member_right_11"><span>*</span>一句话点评</div>
        <div class="member_right_17"><input  id="txt_title" class="input"  type="text" name="txt_title" onblur="if(this.value==''){this.value=''}" onfocus="if(this.value==''){this.value=''}" runat="server" maxlength="30"
        />
        </div>

        <div class="member_right_15"id="div_title_error">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11"><span>*</span>购车日期</div>
        <div class="member_right_19"><input value="" class="input" id="txt_buydate" runat="server" readonly="true" type="text" name="txt_buydate" onblur="if(this.value==''){this.value=''}" onfocus="if(this.value==''){this.value=''}"   />
        </div>
        <div id="div1" class="member_right_15">
              <span id="buydate_e"style="display:none"></span>
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11"><span>*</span>裸车价格</div>
        <div class="member_right_19"><input value="" class="input" id="txt_buyprice"  runat="server"  type="text" name="txt_buyprice" onblur="if(this.value==''){this.value=''}" onfocus="if(this.value==''){this.value=''}" maxlength="6" />
        </div>
        <div class="member_right_20">万元</div>
        <div id="div_buyprice_error" class="member_right_15">
              <span id="div_buyprice_error1"style="display:none"></span>
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11"><span>*</span>购车地点</div>
        <div class="member_right_12">
        <select  name="pro_c" id="pro_c" onchange="pro_change()" class="member_right_13">
            <option>省份选择</option>
            <option>选择品牌</option>
            <option>选择品牌</option>
            <option>选择品牌</option>
        </select>
        </div>
        <div class="member_right_12">
        <select  name="city_c" id="city_c" class="member_right_13">
            <option>城市选择</option>
            <option>选择品牌</option>
            <option>选择品牌</option>
            <option>选择品牌</option>
        </select>
        </div>
        <div class="member_right_14">
        <select  name="select" id="M_ID" class="member_right_13">
        <option value="0">经销商</option>
        </select>
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11"><span>*</span>油耗</div>
        <div class="member_right_19"><input value="" class="input" id="txt_car_oil" runat="server" type="text" name="txt_car_oil" onblur="if(this.value==''){this.value=''}" onfocus="if(this.value==''){this.value=''}" maxlength="6" />
        </div>
        <div class="member_right_20">L/100km</div>
        <div id="div_oil_error" class="member_right_15">
        </div>

      </div>
      <div class="member_right_10">
        <div class="member_right_11">油耗</div>
        <div class="member_right_21 block clearfix"id="star_oil" star="<%=oilstar%>"> <div id="Div2" class="star_score"  runat="server"></div>  </div>
        <div class="member_right_22"><input   runat="server" class="input" id="txt_oil_summary" type="text" name="txt_oil_summary"
        value="在市区、郊区、高速上，油耗表现怎么样？"  onblur="if(this.value==''){this.value='在市区、郊区、高速上，油耗表现怎么样？'}" onfocus="if(this.value=='在市区、郊区、高速上，油耗表现怎么样？'){this.value=''}" />
        </div>
        <div id="error_oil" class="member_right_15">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11">操控</div>
        <div class="member_right_21 block clearfix"id="star_drive" star="<%=drivestar %>" > <div id="Div3" class="star_score" runat="server"></div>  </div>
        <div class="member_right_22"><input   runat="server"  class="input" id="txt_drive_summary"  type="text" name="txt_drive_summary" value="转向是否精准？过弯是否够硬？刹车是否灵敏？" onblur="if(this.value==''){this.value='转向是否精准？过弯是否够硬？刹车是否灵敏？'}" onfocus="if(this.value=='转向是否精准？过弯是否够硬？刹车是否灵敏？'){this.value=''}" />
        </div>
        <div class="member_right_15" id="error_drive">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11">性价比</div>
        <div class="member_right_21 block clearfix"id="star_cost" star="<%=coststar %>"> <div class="star_score"></div>  </div>
        <div class="member_right_22"><input    runat="server" class="input" id="txt_cost_summary" type="text" name="txt_cost_summary"   value="花了多少钱呢？觉得性价比怎么样？"   onblur="if(this.value==''){this.value='花了多少钱呢？觉得性价比怎么样？'}" onfocus="if(this.value=='花了多少钱呢？觉得性价比怎么样？'){this.value=''}" />
        </div>
        <div class="member_right_15" id="error_cost">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11">动力</div>
        <div class="member_right_21 block clearfix"id="star_power" star="<%=powerstar %>" > <div class="star_score"></div>  </div>
        <div class="member_right_22"><input  runat="server" class="input" id="txt_power_summary" type="text" name="txt_power_summary"  value="动力方面表现怎么样？" onblur="if(this.value==''){this.value='动力方面表现怎么样？'}" onfocus="if(this.value=='动力方面表现怎么样？'){this.value=''}" />
        </div>
        <div class="member_right_15" id="error_power">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11">配置</div>
        <div class="member_right_21 block clearfix"id="star_config" star="<%=configstar %>"> <div class="star_score"></div>  </div>
        <div class="member_right_22"><input runat="server" class="input" id="txt_config_summary" type="text" name="txt_config_summary" value="功能配置有何亮点？还有什么不太满意的吗？" onblur="if(this.value==''){this.value='功能配置有何亮点？还有什么不太满意的吗？'}" onfocus="if(this.value=='功能配置有何亮点？还有什么不太满意的吗？'){this.value=''}" />
        </div>
        <div class="member_right_15" id="error_config">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11">舒适度</div>
        <div class="member_right_21 block clearfix"id="star_comfort" star="<%=comfortstar %>"> <div class="star_score"></div>  </div>
        <div class="member_right_22"><input   runat="server" class="input" id="txt_comfort_summary" type="text" name="txt_comfort_summary"  value="座椅合适吗？有噪音吗？车是否有颠簸感？"  onblur="if(this.value==''){this.value='座椅合适吗？有噪音吗？车是否有颠簸感？'}" onfocus="if(this.value=='座椅合适吗？有噪音吗？车是否有颠簸感？'){this.value=''}" />
        </div>
        <div class="member_right_15"id="error_comfort">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11">空间</div>
        <div class="member_right_21 block clearfix"id="star_space" star="<%=spacestar %>" > <div class="star_score"></div>  </div>
        <div class="member_right_22"><input   runat="server" class="input" id="txt_space_summary" type="text" name="txt_space_summary"    value="乘坐空间和载物空间怎么样？" onblur="if(this.value==''){this.value='乘坐空间和载物空间怎么样？'}" onfocus="if(this.value=='乘坐空间和载物空间怎么样？'){this.value=''}" />
        </div>
        <div class="member_right_15" id="error_space">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11">外观</div>
        <div class="member_right_21 block clearfix"id="star_appearance" star="<%=apperstar %>"> <div class="star_score"></div>  </div>
        <div class="member_right_22"><input   class="input"  runat="server" id="txt_appearance_summary"  type="text" name="txt_appearance_summary" value="颜值如何？对Ta的线条、外观、轮毂满意吗？"  onblur="if(this.value==''){this.value='颜值如何？对Ta的线条、外观、轮毂满意吗？'}" onfocus="if(this.value=='颜值如何？对Ta的线条、外观、轮毂满意吗？'){this.value=''}" />
        </div>
        <div class="member_right_15" id="error_appearance">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11">内饰</div>
        <div class="member_right_21 block clearfix"id="star_inside" star="<%=insidestar%>"> <div class="star_score"></div>  </div>
        <div class="member_right_22"><input   class="input"  runat="server" id="txt_inside_summary" type="text" name="txt_inside_summary"   value="内饰的做工，用料怎么样？"
 onblur="if(this.value==''){this.value='内饰的做工，用料怎么样？'}" onfocus="if(this.value=='内饰的做工，用料怎么样？'){this.value=''}" />
        </div>
        <div class="member_right_15" id="error_inside">
        </div>
      </div>
      <div class="member_right_10">
        <div class="member_right_11"><span>*</span>综合评分</div>
        <div class="member_right_21 block clearfix" id="star_all" star="<%=allstar%>"> <div class="star_score"></div>  </div>
      </div>      
      <div class="member_right_10">
        <div class="member_right_11"><span>*</span>综合点评</div>
        <div class="member_right_23"><textarea rows="5"  id="txt_all_summary" runat="server" style=" width:766px; height:200px; resize:none;"></textarea></div>
        <div class="member_right_15" id="error_all">
        </div>
      </div>
      
      <div class="member_right_24">
      <ul>
      <li><input type="button"  id="butn_send" value="发布" class="link_4" /></li>
      </ul>
      </div>
      </div>
  </div>
    <script src="js/startScore.js" type="text/javascript"></script>
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/jquery_ui.js" type="text/javascript"></script>
    <script src="js/brand.js" type="text/javascript"></script>
    <script src="js/common.js" type="text/javascript"></script>
    <script src="js/js_tool.js" type="text/javascript"></script>
    <script src="js/kb_validate.js" type="text/javascript"></script>
    <script src="js/list.js" type="text/javascript"></script>
    <script src="js/Release.js" type="text/javascript"></script>
<%--<script src="js/kb_rels.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
    $(function(){
        bind(<%=series %>);
        });
    </script>
</body>
</html>
