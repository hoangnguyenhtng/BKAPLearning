package bpweb.controller.admin;

import java.io.IOException;
import java.util.List;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import bpweb.model.Catalog;
import bpweb.model.Product;
import bpweb.service.CategoryService;
import bpweb.service.ProductService;
import bpweb.service.impl.CategoryServicesImpl;
import bpweb.service.impl.ProductServiceImpl;

/**
 * Servlet implementation class ProductListController
 */
public class ProductListController extends HttpServlet {
	private static final long serialVersionUID = 1L;

	ProductService productService = new ProductServiceImpl();
	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		List<Product> productList = productService.getAll();
		req.setAttribute("productlist", productList);
		RequestDispatcher dispatcher = req.getRequestDispatcher("/view/admin/show-product.jsp");
		dispatcher.forward(req, resp);
	}
}
