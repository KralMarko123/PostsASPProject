const BASE_URL_DEV = "https://localhost:7171";
const BASE_URL_PRODUCTION = "https://posts-aspnetserver.azurewebsites.net";

const ENDPOINTS = {
	//POSTS
	GET_ALL_POSTS: "get-all-posts",
	GET_POST_BY_ID: "get-post-by-id",
	CREATE_POST: "create-post",
	UPDATE_POST: "update-post",
	DELETE_POST_BY_ID: "delete-post-by-id",
	TOGGLE_POST_HIDDEN: "toggle-post-visibility",
	TOGGLE_USER_FOR_POST: "toggle-user-for-post",

	//USERS
	GET_ALL_USERS: "get-all-users",

	//AUTH
	LOGIN: "login",
	REGISTER: "register",
	HUB: "postHub",
};

const development = {
	//POSTS
	GET_ALL_POSTS: `${BASE_URL_DEV}/${ENDPOINTS.GET_ALL_POSTS}`,
	GET_POST_BY_ID: `${BASE_URL_DEV}/${ENDPOINTS.GET_POST_BY_ID}`,
	CREATE_POST: `${BASE_URL_DEV}/${ENDPOINTS.CREATE_POST}`,
	UPDATE_POST: `${BASE_URL_DEV}/${ENDPOINTS.UPDATE_POST}`,
	DELETE_POST_BY_ID: `${BASE_URL_DEV}/${ENDPOINTS.DELETE_POST_BY_ID}`,
	TOGGLE_POST_HIDDEN: `${BASE_URL_DEV}/${ENDPOINTS.TOGGLE_POST_HIDDEN}`,
	TOGGLE_USER_FOR_POST: `${BASE_URL_DEV}/${ENDPOINTS.TOGGLE_USER_FOR_POST}`,

	//USERS
	GET_ALL_USERS: `${BASE_URL_DEV}/${ENDPOINTS.GET_ALL_USERS}`,

	//AUTH
	LOGIN: `${BASE_URL_DEV}/${ENDPOINTS.LOGIN}`,
	REGISTER: `${BASE_URL_DEV}/${ENDPOINTS.REGISTER}`,
	HUB: `${BASE_URL_DEV}/${ENDPOINTS.HUB}`,
};

const production = {
	//POSTS
	GET_ALL_POSTS: `${BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_POSTS}`,
	GET_POST_BY_ID: `${BASE_URL_PRODUCTION}/${ENDPOINTS.GET_POST_BY_ID}`,
	CREATE_POST: `${BASE_URL_PRODUCTION}/${ENDPOINTS.CREATE_POST}`,
	UPDATE_POST: `${BASE_URL_PRODUCTION}/${ENDPOINTS.UPDATE_POST}`,
	DELETE_POST_BY_ID: `${BASE_URL_PRODUCTION}/${ENDPOINTS.DELETE_POST_BY_ID}`,
	TOGGLE_POST_HIDDEN: `${BASE_URL_PRODUCTION}/${ENDPOINTS.TOGGLE_POST_HIDDEN}`,
	TOGGLE_USER_FOR_POST: `${BASE_URL_PRODUCTION}/${ENDPOINTS.TOGGLE_USER_FOR_POST}`,

	//USERS
	GET_ALL_USERS: `${BASE_URL_PRODUCTION}/${ENDPOINTS.GET_ALL_USERS}`,

	//AUTH
	LOGIN: `${BASE_URL_PRODUCTION}/${ENDPOINTS.LOGIN}`,
	REGISTER: `${BASE_URL_PRODUCTION}/${ENDPOINTS.REGISTER}`,
	HUB: `${BASE_URL_PRODUCTION}/${ENDPOINTS.HUB}`,
};

const ENDPOINT__URLS = process.env.NODE_ENV === "development" ? development : production;

export default ENDPOINT__URLS;
